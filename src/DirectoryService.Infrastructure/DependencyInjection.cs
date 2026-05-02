using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DirectoryService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isDevelopment)
    {
        services.AddDbContextPool<DirectoryServiceDbContext>((sp, options) =>
        {
            string connectionString = configuration.GetConnectionString(Constants.DATABASE)!;

            options.UseNpgsql(connectionString);

            if (isDevelopment)
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }

            ILoggerFactory loggerFactory = sp.GetRequiredService<ILoggerFactory>();

            options.UseLoggerFactory(loggerFactory);
        });

        return services;
    }
}