using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;

namespace ServiceHeft.Persistence.EntityFramework.EntityConfigurations;

public class ModelEntityTypeConfiguration : IEntityTypeConfiguration<Model>
{
    private const int ModelNameMaxLength = 40;

    private readonly ISeedingDataRepository<Model> _repository;

    public ModelEntityTypeConfiguration(ISeedingDataRepository<Model> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(m => new { m.Manufacturer, m.InternalName });
        builder.Property(m => m.InternalName).HasMaxLength(ModelNameMaxLength);
        builder.Property(m => m.OfficialName).HasMaxLength(ModelNameMaxLength);

        var seedModels = _repository.Read();

        builder.HasData(seedModels);
    }
}
