using ServiceHeft.Maintenance.Contracts.Maintenance;

namespace ServiceHeft.Maintenance.Domain;

public class MaintenanceAggregatingService : IMaintenanceAggregateService
{
    public Task GetCarServiceAggregate(Guid carId)
    {
        throw new NotImplementedException();
    }
}
