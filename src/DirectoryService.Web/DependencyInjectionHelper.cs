using DirectoryService.Application;

namespace DirectoryService.Web;

internal static class DependencyInjectionHelper
{
    public static IServiceCollection AddProgram(this IServiceCollection services)
    {
        services
            .AddWebDependencies()
            .AddApplication();
        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddControllers();

        return services;
    }
}