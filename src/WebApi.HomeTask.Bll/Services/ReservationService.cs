using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Bll.Abstractions;
using WebApi.HomeTask.Bll.Dto;
using WebApi.HomeTask.Bll.Exceptions;
using WebApi.HomeTask.Dal.Abstraction;
using WebApi.HomeTask.Dal.Entities;
using WebApi.HomeTask.Shared.Abstraction;
using WebApi.HomeTask.Shared.Messages;

namespace WebApi.HomeTask.Bll.Services;

public class ReservationService : IReservationService
{
    private readonly ILookupGenericRepository<RestaurantEntity> _restaurantRepository;
    private readonly ITableSizeRepository _tableSizeRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly ILogger<ReservationService> _logger;

    public ReservationService(ILookupGenericRepository<RestaurantEntity> restaurantRepository,
        ITableSizeRepository tableSizeRepository,
        IReservationRepository reservationRepository,
        ILogger<ReservationService> logger)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        _tableSizeRepository = tableSizeRepository ?? throw new ArgumentNullException(nameof(tableSizeRepository));
        _reservationRepository =
            reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ReservationResponseDto> CreateReservation(ReservationRequestDto reservationRequestDto)
    {
        _logger.LogDebug(
            "ReservationService.CreateReservation args: RestaurantName:{0}, NumberOfPeople:{2}, ReservationDateTime:{3}",
            reservationRequestDto.RestaurantName, reservationRequestDto.NumberOfPeople,
            reservationRequestDto.ReservationDateTime);

        // TODO: Add redis cache for get table size and get restaurant
        var tableSizeIdResult = await _tableSizeRepository.GetTableSizeIdAsync(reservationRequestDto.NumberOfPeople);
        var restaurantEntity = await _restaurantRepository.GetByNameQueryable(reservationRequestDto.RestaurantName)
            .Include(q => q.TablesSummary).FirstOrDefaultAsync();

        ValidateData(reservationRequestDto, restaurantEntity, tableSizeIdResult);
        var tableSizeId = tableSizeIdResult!.Value;
        
        _logger.LogDebug(
            "ReservationService.CreateReservation tableSizeIdResult:{0}, restaurantEntity:{2}",
            tableSizeId, restaurantEntity.Name);
        
        // Check if any table possible to be available.
        var maxAmountOfTableWithSuchSize =
            restaurantEntity!.TablesSummary.First(q => q.TableSizeId == tableSizeId).Amount;
        var (anyAvailableTable, reservedTablesIds) = await _reservationRepository.CheckTableReservation(
            restaurantEntity.Id, tableSizeId,
            reservationRequestDto.ReservationDateTime, maxAmountOfTableWithSuchSize);

        if (!anyAvailableTable)
        {
            throw new NoAvailableTableException(ExceptionMessages.NoAvailableTables);
        }

        var nextAvailableTableId =await _tableSizeRepository.GetAvailableTableIdAsync(restaurantEntity.Id, tableSizeId, reservedTablesIds);
        if (nextAvailableTableId == null)
        {
            throw new NoAvailableTableException(ExceptionMessages.NoAvailableTables);
        }

        //TODO: Remove stubs change to params;
        var reservation = await _reservationRepository.CreateReservation(nextAvailableTableId.Value,
            restaurantEntity.Id,
            reservationRequestDto.ReservationDateTime, tableSizeId, "OwnerName", "OwnerPhone");

        return new ReservationResponseDto
        {
            ReservationId = reservation.Id,
            StartTime = DateTimeOffset.FromUnixTimeMilliseconds(reservation.StartTimeEpoch),
            EndTime = DateTimeOffset.FromUnixTimeMilliseconds(reservation.EndTimeEpoch),
            TableId = nextAvailableTableId.Value,
            RestaurantId = restaurantEntity.Id
        };
    }

    private static void ValidateData(ReservationRequestDto reservationRequestDto, RestaurantEntity? restaurant,
        int? tableSizeId)
    {
        if (restaurant == null)
        {
            throw new NotFoundException(
                ExceptionMessages.BuildRestaurantNotFoundMessage(reservationRequestDto.RestaurantName));
        }

        // Validate restaurant working hours
        if (restaurant.OpenTime > reservationRequestDto.ReservationDateTime.TimeOfDay.Ticks ||
            reservationRequestDto.ReservationDateTime.TimeOfDay.Ticks > restaurant.CloseTime)
        {
            throw new OutOfWorkingHoursException(
                ExceptionMessages.BuildOutOfWorkingHoursMessage(restaurant.OpenTime, restaurant.CloseTime));
        }

        if (tableSizeId == null)
        {
            throw new OutOfTableSizeException(
                $"Number Of People:{reservationRequestDto.NumberOfPeople} is larger then the biggest available table.");
        }
    }
}