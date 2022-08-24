using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal;
using WebApi.HomeTask.Dal.Infrastructure;
using WebApi.HomeTask.Shared.Abstraction;

namespace WebApi.HomeTask.Shared;

public class LookupGenericRepository<T> : GenericRepository<T>, ILookupGenericRepository<T> where T : NameableEntity
{
    public LookupGenericRepository(RestaurantDbContext context, ILogger<GenericRepository<T>> logger) : base(context,
        logger)
    {
    }

    public async Task<T?> GetByNameAsync(string name)
    {
        Logger.LogDebug("LookupGenericRepository.GetByNameAsync");
        return await Context.Set<T>()
            .FirstOrDefaultAsync(q => string.Equals(q.Name, name, StringComparison.CurrentCultureIgnoreCase));
    }

    public IQueryable<T> GetByNameQueryable(string name)
    {
        Logger.LogDebug("LookupGenericRepository.GetByNameAsync");
        return Context.Set<T>()
            .Where(q => string.Equals(q.Name, name, StringComparison.CurrentCultureIgnoreCase));
    }
}