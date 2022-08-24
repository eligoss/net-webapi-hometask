using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WebApi.HomeTask.Bll.Abstractions;
using WebApi.HomeTask.Bll.Services;
using WebApi.HomeTask.Dal.Abstraction;
using WebApi.HomeTask.Dal.Repositories;

namespace WebApi.HomeTask.Bll.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient<IReservationService, ReservationService>();
        services.AddTransient<IReservationRepository, ReservationRepository>();
        services.AddTransient<ITableSizeRepository, TableSizeRepository>();

        return services;
    }
}