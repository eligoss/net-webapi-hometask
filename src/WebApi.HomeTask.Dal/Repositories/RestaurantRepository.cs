using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal.Abstraction;
using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _restaurantDbContext;
    private readonly ILogger<RestaurantRepository> _logger;

    public RestaurantRepository(RestaurantDbContext restaurantDbContext, ILogger<RestaurantRepository> logger)
    {
        _restaurantDbContext = restaurantDbContext;
        _logger = logger;
    }

    //TODO: Extract to generic method
    public async Task<RestaurantEntity?> GetRestaurant(string name)
    {
        _logger.LogDebug("RestaurantRepository.GetRestaurant args: name{0}", name);

        return await _restaurantDbContext.Restaurants
            .Where(q => string.Equals(q.Name, name, StringComparison.CurrentCultureIgnoreCase))
            .Include(q => q.TablesSummary)
            .FirstOrDefaultAsync();
    }
}