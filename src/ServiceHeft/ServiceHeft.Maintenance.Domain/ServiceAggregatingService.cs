using ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Maintenance.Domain;

public class ServiceAggregatingService : IMaintenanceAggregateService
{
    public Task GetCarServiceAggregate(Guid carId)
    {
        throw new NotImplementedException();
    }
}
