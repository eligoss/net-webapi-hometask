using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Shared.Abstraction;

public interface ILookupGenericRepository<T> : IGenericRepository<T> where T : NameableEntity
{
    public Task<T?> GetByNameAsync(string name);

    public IQueryable<T> GetByNameQueryable(string name);
}