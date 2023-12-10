using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Automotive;

namespace ServiceHeft.Persistence.EntityFramework.Configurations;

public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
{
    /// <summary>
    /// Vehicle Identification Number (VIN) has always exactly 17 characters
    /// </summary>
    private const int VinMaximumLength = 17;

    /// <summary>
    /// Due to various international standards a buffer was taken into account.
    /// </summary>
    private const int LicencePlateMaxLength = 12;

    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasAlternateKey(c => c.Vin);
        builder.Property(c => c.Vin).HasMaxLength(VinMaximumLength);
        builder.Property(c => c.LicencePlate).HasMaxLength(LicencePlateMaxLength);

        builder.OwnsOne(c => c.Engine, e =>
        {
            e.Property<Guid>("CarId");
            e.WithOwner();
        });
    }
}
