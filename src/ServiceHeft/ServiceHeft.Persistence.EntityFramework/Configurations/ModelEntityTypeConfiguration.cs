using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Automotive;

namespace ServiceHeft.Persistence.EntityFramework.Configurations;

public class ModelEntityTypeConfiguration : IEntityTypeConfiguration<Model>
{
    private const int ModelNameMaxLength = 40;

    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(m => new { m.Manufacturer, m.InternalName });
        builder.Property(m => m.InternalName).HasMaxLength(ModelNameMaxLength);
        builder.Property(m => m.OfficialName).HasMaxLength(ModelNameMaxLength);
    }
}
