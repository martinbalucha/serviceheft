using Microsoft.EntityFrameworkCore;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Maintenance;
using ServiceHeft.Persistence.EntityFramework.Configurations;

namespace ServiceHeft.Persistence.EntityFramework.DataAccess;

public class ServiceHeftDbContext : DbContext
{
    protected DbSet<ServiceRecord> ServiceRecords { get; init; }
    protected DbSet<Car> Cars { get; init; }
    protected DbSet<Autopart> Autoparts { get; init; }

    public ServiceHeftDbContext(DbContextOptions<ServiceHeftDbContext> options) : base(options)
    {    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarEntityTypeConfiguration).Assembly);
    }
}
