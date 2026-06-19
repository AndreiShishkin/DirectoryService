using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("locations");

        builder.HasKey(l => l.Id).HasName("pk_location_id");

        builder.ComplexProperty(l => l.Name, cb =>
        {
            cb
                .Property(l => l.Value)
                .IsRequired()
                .HasMaxLength(LocationName.MAX_LENGTH)
                .HasColumnName("name");
        });

        builder.OwnsOne(l => l.Address, nb =>
        {
            nb.ToJson("address");

            nb
                .Property(p => p.Region)
                .IsRequired()
                .HasColumnName("region");

            nb
                .Property(p => p.City)
                .IsRequired()
                .HasColumnName("city");

            nb
                .Property(p => p.Street)
                .IsRequired()
                .HasColumnName("street");

            nb
                .Property(p => p.House)
                .IsRequired()
                .HasColumnName("house");

            nb
                .Property(p => p.Apartment)
                .HasColumnName("apartment");

            nb
                .Property(p => p.PostalCode)
                .HasColumnName("postal_code");
        });

        builder.ComplexProperty(l => l.Timezone, cb =>
        {
            cb.Property(tz => tz.Value)
                .IsRequired()
                .HasColumnName("timezone");
        });

        builder
            .Property(d => d.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_active");

        builder
            .Property(d => d.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder
            .Property(d => d.UpdatedAt)
            .HasColumnName("updated_at");
    }
}