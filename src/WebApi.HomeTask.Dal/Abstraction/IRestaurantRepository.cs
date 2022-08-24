using WebApi.HomeTask.Dal.Entities;

namespace WebApi.HomeTask.Dal.Abstraction;

public interface IRestaurantRepository
{
    public Task<RestaurantEntity?> GetRestaurant(string name);
}