using Microsoft.EntityFrameworkCore;
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
    private string _message;


    public ReservationService(ILookupGenericRepository<RestaurantEntity> restaurantRepository,
        ITableSizeRepository tableSizeRepository,
        IReservationRepository reservationRepository)
    {
        _restaurantRepository = restaurantRepository ?? throw new ArgumentNullException(nameof(restaurantRepository));
        _tableSizeRepository = tableSizeRepository ?? throw new ArgumentNullException(nameof(tableSizeRepository));
        _reservationRepository =
            reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
    }

    public async Task CreateReservation(ReservationDto reservationDto)
    {
        var taskTableSize = _tableSizeRepository.GetTableSizeIdAsync(reservationDto.NumberOfPeople);
        var taskRestaurant = _restaurantRepository.GetByNameQueryable(reservationDto.RestaurantName)
            .Include(q => q.TablesSummary).FirstOrDefaultAsync();

        await Task.WhenAll(taskTableSize, taskRestaurant);

        var tableSizeId = taskTableSize.Result;
        var restaurant = taskRestaurant.Result;

        if (restaurant == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.RestaurantNotFound,
                reservationDto.RestaurantName));
        }

        var maxAmountOfTable = restaurant.TablesSummary.First(q => q.TableSizeId == tableSizeId).Amount;

        var tableAvailability = await _reservationRepository.CheckTableReservation(restaurant.Id, tableSizeId,
            reservationDto.ReservationDateTime, maxAmountOfTable);


        if (!tableAvailability.shouldHaveAvailableTable)
        {
            throw new NoAvailableTableException(ExceptionMessages.NoAvailableTables);
        }

        var availableTableId = await _tableSizeRepository.GetAvailableTableIdAsync(restaurant.Id, tableSizeId,
            tableAvailability.alreadyBookedTables);

        if (availableTableId == null)
        {
            throw new NoAvailableTableException(ExceptionMessages.NoAvailableTables);
        }
        
        //TODO: Remove stubs change to params;
        await _reservationRepository.CreateReservation(availableTableId.Value, restaurant.Id,
            reservationDto.ReservationDateTime, tableSizeId, "OwnerName", "OwnerPhone");
    }
}