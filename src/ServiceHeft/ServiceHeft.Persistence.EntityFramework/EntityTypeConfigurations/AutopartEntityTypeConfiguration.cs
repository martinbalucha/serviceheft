using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Maintenance;

namespace ServiceHeft.Persistence.EntityFramework.EntityConfigurations;

public class AutopartEntityTypeConfiguration : IEntityTypeConfiguration<Autopart>
{
    private const int NameMaxLength = 60;
    private const int ProducerMaxLength = 60;

    public void Configure(EntityTypeBuilder<Autopart> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).HasMaxLength(NameMaxLength);
        builder.Property(a => a.Producer).HasMaxLength(ProducerMaxLength);
    }
}