using Serilog;
using ServiceHeft.Maintenance.Contracts.Maintenance;

namespace ServiceHeft.Maintenance.Domain;

public class MaintenanceAggregatingService : IMaintenanceAggregateService
{
    private readonly ILogger logger;

    public MaintenanceAggregatingService(ILogger logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task GetCarServiceAggregate(Guid carId)
    {
        throw new NotImplementedException();
    }
}
