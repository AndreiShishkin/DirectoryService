using DirectoryService.Application.Locations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Application;

public static class DependencyInjectionHelper
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjectionHelper).Assembly);
        services.AddScoped<ILocationsService, LocationsService>();
        services.AddScoped<IValidator, CreateLocationValidator>();

        return services;
    }
}