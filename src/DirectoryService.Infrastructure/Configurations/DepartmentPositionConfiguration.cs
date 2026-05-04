using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Positions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
{
    public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.ToTable("department_position");

        builder.HasKey(dp => dp.Id).HasName("department_position_id");

        builder.Property(dp => dp.PositionId).HasColumnName("position_id");

        builder
            .HasOne<Position>()
            .WithMany()
            .HasForeignKey(dp => dp.PositionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}