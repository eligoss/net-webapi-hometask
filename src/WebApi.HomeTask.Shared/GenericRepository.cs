using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.HomeTask.Dal;
using WebApi.HomeTask.Dal.Infrastructure;
using WebApi.HomeTask.Shared.Abstraction;

namespace WebApi.HomeTask.Shared;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
    protected readonly RestaurantDbContext Context;
    protected readonly ILogger<GenericRepository<T>> Logger;

    public GenericRepository(RestaurantDbContext context, ILogger<GenericRepository<T>> logger)
    {
        Context = context;
        Logger = logger;
    }

    public async Task<T> AddAsync(T entity)
    {
        Logger.LogDebug("GenericRepository.AddAsync");

        await Context.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        Logger.LogDebug("GenericRepository.Delete");

        Context.Set<T>().Remove(entity);
    }

    public void DeleteRange(ICollection<T> entities)
    {
        Logger.LogDebug("GenericRepository.DeleteRange");
        Context.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        Logger.LogDebug("GenericRepository.Update");

        Context.Set<T>().Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        Logger.LogDebug("GenericRepository.GetByIdAsync");
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        Logger.LogDebug("GenericRepository.ListAllAsync");
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<bool> AnyAsync()
    {
        Logger.LogDebug("GenericRepository.AnyAsync");
        return await Context.Set<T>().AnyAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        Logger.LogDebug("GenericRepository.SaveChangesAsync");
        return await Context.SaveChangesAsync();
    }
}