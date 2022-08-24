using WebApi.HomeTask.Dal.Infrastructure;

namespace WebApi.HomeTask.Shared.Abstraction;

public interface IGenericRepository<T> where T : BaseAuditableEntity
{
    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> ListAllAsync();

    Task<T> AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);

    void DeleteRange(ICollection<T> entities);

    Task<bool> AnyAsync();

    Task<int> SaveChangesAsync();
}