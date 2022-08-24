namespace WebApi.HomeTask.Dal.Abstraction;

public interface IReservationRepository
{
    public Task<(bool shouldHaveAvailableTable, ICollection<int> alreadyBookedTables)> CheckTableReservation(int restaurantId,
        int tableSizeId,
        DateTimeOffset startTime, int amountOfTables);

    Task CreateReservation(int availableTableId, int restaurantId, DateTimeOffset reservationDtoReservationDateTime, int tableSizeId, string ownerName, string ownerPhone);
}