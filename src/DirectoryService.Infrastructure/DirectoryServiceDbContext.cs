using Microsoft.EntityFrameworkCore;

namespace DirectoryService.Infrastructure;

public class DirectoryServiceDbContext(DbContextOptions<DirectoryServiceDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryServiceDbContext).Assembly);
    }
}