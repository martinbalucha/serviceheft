using Microsoft.EntityFrameworkCore;
using ServiceHeft.Contracts.Servicing.Automotive;
using ServiceHeft.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Server.Persistence;

public class ServiceHeftDbContext : DbContext
{
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<Car> Cars { get; set; }

    public ServiceHeftDbContext(DbContextOptions<ServiceHeftDbContext> options) : base(options)
    {    
    }
}
