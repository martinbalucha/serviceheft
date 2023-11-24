namespace ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

/// <summary>
/// Provides aggregation of maintenance performed on <see cref="Car"/>
/// </summary>
public interface IMaintenanceAggregateService
{
    Task GetCarServiceAggregate(Guid carId);
}
