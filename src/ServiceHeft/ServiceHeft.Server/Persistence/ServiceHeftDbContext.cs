using Microsoft.EntityFrameworkCore;
using ServiceHeft.Maintenance.Contracts.Servicing.Automotive;
using ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Server.Persistence;

public class ServiceHeftDbContext : DbContext
{
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<Car> Cars { get; set; }

    public ServiceHeftDbContext(DbContextOptions<ServiceHeftDbContext> options) : base(options)
    {    
    }
}
