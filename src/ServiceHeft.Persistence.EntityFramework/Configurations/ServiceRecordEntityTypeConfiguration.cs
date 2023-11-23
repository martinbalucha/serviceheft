using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Persistence.EntityFramework.Configurations;

public class ServiceRecordEntityTypeConfiguration : IEntityTypeConfiguration<ServiceRecord>
{
    private const int NameMaxLength = 256;
    private const int DescriptionMaxLength = 1000;

    public void Configure(EntityTypeBuilder<ServiceRecord> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(NameMaxLength);
        builder.Property(x => x.Description).HasMaxLength(DescriptionMaxLength);
        
        builder.HasMany(x => x.PartsChanged);
    }
}
