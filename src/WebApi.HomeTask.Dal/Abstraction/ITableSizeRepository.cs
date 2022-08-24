namespace WebApi.HomeTask.Dal.Abstraction;

public interface ITableSizeRepository
{
    public Task<int?> GetTableSizeIdAsync(int peopleCount);

    public Task<int?> GetAvailableTableIdAsync(int restaurantId, int tableSizeId, ICollection<int> blockedTables);
}