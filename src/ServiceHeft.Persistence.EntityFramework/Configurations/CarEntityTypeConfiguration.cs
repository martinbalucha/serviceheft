﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceHeft.Maintenance.Contracts.Servicing.Automotive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        builder.Property(c => c.Vin).HasMaxLength(VinMaximumLength);
        builder.Property(c => c.LicencePlate).HasMaxLength(LicencePlateMaxLength);

        builder.OwnsOne(c => c.ModelInfo, mi =>
        {
            mi.Property<Guid>("CarId");
            mi.WithOwner();
        });

        builder.OwnsMany(c => c.ServiceRecords);
    }
}
