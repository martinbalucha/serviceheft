using ServiceHeft.Contracts.Servicing.Automotive;
using ServiceHeft.Contracts.Servicing.Common;

namespace ServiceHeft.Contracts.Servicing.Maintenance;

public class ServiceRecord : Entity
{
    private readonly List<Autopart> _partsChanged = new ();

    public Car Car { get; private set; }
    public DateTime PerformedOn { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public IMoney TotalLaborCost { get; private set; }
    public IReadOnlyList<Autopart> PartsChanged => _partsChanged;

    public IMoney TotalCost => TotalLaborCost;

    public ServiceRecord(Guid id, Car car, string name, string description, IMoney laborCost) : base(id)
    {
        Car = car;
        Name = name;
        Description = description;
        TotalLaborCost = laborCost;
        PerformedOn = DateTime.UtcNow;
    }

    public void PerformService(Autopart autopart, IMoney laborCost)
    {
        _partsChanged.Add(autopart);
        TotalLaborCost.Add(laborCost);
    }
}
