using DirectoryService.Domain.Positions;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("positions");

        builder.HasKey(d => d.Id).HasName("pk_position_id");

        builder.ComplexProperty(p => p.Name, cb =>
        {
            cb
                .Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(PositionName.MAX_LENGTH)
                .HasColumnName("name");
        });

        builder.ComplexProperty(p => p.Description, cb =>
        {
            cb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Description.MAX_QUANTITY)
                .HasColumnName("description");
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