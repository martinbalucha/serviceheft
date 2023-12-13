using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Maintenance;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;
using ServiceHeft.Persistence.EntityFramework.EntityConfigurations;

namespace ServiceHeft.Persistence.EntityFramework.DataAccess;

public class ServiceHeftDbContext : DbContext
{
    public DbSet<ServiceRecord> ServiceRecords { get; init; }
    public DbSet<Car> Cars { get; init; }
    public DbSet<Autopart> Autoparts { get; init; }

    public ServiceHeftDbContext(DbContextOptions<ServiceHeftDbContext> options) : base(options)
    {    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var factory = Database.GetService<ISeedingDataRepositoryFactory>();
        
        modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceRecordEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AutopartEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ModelEntityTypeConfiguration(factory));
    }
}
