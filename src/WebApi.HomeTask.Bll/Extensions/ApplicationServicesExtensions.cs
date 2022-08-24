using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.HomeTask.Bll.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


        return services;
    }
}