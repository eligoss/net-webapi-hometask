using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.HomeTask.Dal;
using WebApi.HomeTask.Shared.Abstraction;

namespace WebApi.HomeTask.Shared.Extensions;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {

        var a = config.GetConnectionString("DbConnection");
        services.AddDbContext<RestaurantDbContext>(x =>
        {
            x.UseSqlServer(config.GetConnectionString("DbConnection"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}