using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationDepartmentConfiguration : IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("department_location");

        builder.HasKey(d => d.Id).HasName("pk_location_department_id");

        builder.Property(ld => ld.LocationId).HasColumnName("location_id");

        builder
            .HasOne<Location>()
            .WithMany()
            .HasForeignKey(ld => ld.LocationId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}