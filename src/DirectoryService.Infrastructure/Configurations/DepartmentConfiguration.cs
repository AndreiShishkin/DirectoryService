using DirectoryService.Domain.Departments;
using DirectoryService.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("departments");

        builder.HasKey(x => x.Id).HasName("pk_department_id");

        builder
            .ComplexProperty(d => d.DepartmentName, cb =>
            {
                cb.Property(dn => dn.Value)
                    .IsRequired()
                    .HasMaxLength(DepartmentName.MAX_LENGTH)
                    .HasColumnName("name");
            });

        builder
            .ComplexProperty(d => d.Identifier, cb =>
            {
                cb.Property(d => d.Value)
                    .IsRequired()
                    .HasMaxLength(Identifier.MAX_LENGTH)
                    .HasColumnName("identifier");
            });

        builder
            .Property(d => d.ParentId)
            .HasColumnName("parent_id");

        builder
            .ComplexProperty(d => d.Path, cb =>
            {
                cb.Property(d => d.Value)
                    .IsRequired()
                    .HasColumnName("path");
            });

        builder
            .Property(d => d.Depth)
            .IsRequired()
            .HasColumnName("depth");

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

        builder
            .HasMany(d => d.Locations)
            .WithOne(d => d.Department)
            .HasForeignKey("department_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(d => d.Positions)
            .WithOne(d => d.Department)
            .HasForeignKey("department_id")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}