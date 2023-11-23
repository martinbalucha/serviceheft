using Microsoft.EntityFrameworkCore;
using ServiceHeft.Maintenance.Contracts.Servicing.Automotive;
using ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;
using ServiceHeft.Persistence.EntityFramework.Configurations;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarEntityTypeConfiguration).Assembly);
    }
}
