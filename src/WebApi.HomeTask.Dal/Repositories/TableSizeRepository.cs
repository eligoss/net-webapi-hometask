using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal.Abstraction;

namespace WebApi.HomeTask.Dal.Repositories;

public class TableSizeRepository : ITableSizeRepository
{
    private readonly RestaurantDbContext _restaurantDbContext;
    private readonly ILogger<TableSizeRepository> _logger;


    public TableSizeRepository(RestaurantDbContext restaurantDbContext, ILogger<TableSizeRepository> logger)
    {
        _restaurantDbContext = restaurantDbContext ?? throw new ArgumentNullException(nameof(restaurantDbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<int?> GetTableSizeIdAsync(int peopleCount)
    {
        _logger.LogDebug("TableSizeRepository.GetTableSizeId args: peopleCount:{0}", peopleCount);

        int? result = await _restaurantDbContext.TableSizes.Where(q => q.PeopleCount >= peopleCount)
            .OrderBy(q => q.PeopleCount)
            .Select(q => q.Id)
            .FirstOrDefaultAsync();

        _logger.LogDebug("TableSizeRepository.GetTableSizeId result:{0}", result ?? null);

        return result;
    }

    public async Task<int?> GetAvailableTableIdAsync(int restaurantId, int tableSizeId, ICollection<int> blockedTables)
    {
        _logger.LogDebug(
            "TableSizeRepository.GetAvailableTable args: restaurantId:{0}, tableSizeId{1},blockedTables:{2} ",
            restaurantId, tableSizeId, string.Join(",", blockedTables));

        int? result = await
            _restaurantDbContext.Tables.Where(q =>
                    q.RestaurantId == restaurantId && q.TableSizeId == tableSizeId && !blockedTables.Contains(q.Id))
                .Select(q => q.Id)
                .FirstOrDefaultAsync();

        return result;
    }
}