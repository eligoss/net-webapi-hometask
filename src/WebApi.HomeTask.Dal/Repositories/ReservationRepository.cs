using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal.Abstraction;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantDbContext _restaurantDbContext;
    private readonly ILogger<ReservationRepository> _logger;

    public ReservationRepository(RestaurantDbContext restaurantDbContext, ILogger<ReservationRepository> logger)
    {
        _restaurantDbContext = restaurantDbContext;
        _logger = logger;
    }

    public async Task<(bool, ICollection<int>)> CheckTableReservation(int restaurantId, int tableSizeId,
        DateTimeOffset startTime,
        int amountOfTables)
    {
        _logger.LogDebug(
            "ReservationRepository.CheckTableReservation args: restaurantId{0}, tableSizeId:{1}, startTime:{2} amountOfTables:{3}",
            restaurantId, tableSizeId, startTime,
            amountOfTables);

        // Find how many tables are booked at this time for the restaurant with specific size.
        var tablesReservation = await _restaurantDbContext.Reservations.Where(q =>
                q.RestaurantId == restaurantId && q.TableSizeId == tableSizeId
                                               && q.StartTimeEpoch <= startTime.ToUnixTimeMilliseconds() &&
                                               startTime.ToUnixTimeMilliseconds() >= q.EndTimeEpoch)
            .Select(q => new ReservationEntity
            {
                TableId = q.TableId
            })
            .ToListAsync();

        // If the count is less then maxAmount, so there is available table.
        var result = tablesReservation.Count < amountOfTables;

        _logger.LogDebug("Count of scheduled tables is:{0}, Availability check:{1}", tablesReservation.Count, result);

        return (result, tablesReservation.Select(q => q.TableId).ToList());
    }


    public async Task CreateReservation(int availableTableId, int restaurantId, DateTimeOffset reservationStartDateTime,
        int tableSizeId, string ownerName, string ownerPhone)
    {
        var reservation = new ReservationEntity(restaurantId, availableTableId, tableSizeId, reservationStartDateTime,
            ownerName,
            ownerPhone);

        _restaurantDbContext.Reservations.Add(reservation);
        await _restaurantDbContext.SaveChangesAsync();
    }
}