using ServiceHeft.Maintenance.Contracts.Servicing.Automotive;
using ServiceHeft.Maintenance.Contracts.Servicing.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

public class ServiceRecord : Entity
{
    private readonly List<Autopart> _partsChanged = new ();

    public Guid CarId { get; private set; }

    public DateTime PerformedOn { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    [NotMapped]
    public IMoney TotalLaborCost { get; private set; }

    public IReadOnlyList<Autopart> PartsChanged => _partsChanged;

    [NotMapped]
    public IMoney TotalCost => TotalLaborCost;

    private ServiceRecord() : base(Guid.Empty)
    {
    }

    public ServiceRecord(Guid id, Guid carId, string name, string description, IMoney laborCost) : base(id)
    {
        CarId = carId;
        Name = name;
        Description = description;
        TotalLaborCost = laborCost;
        PerformedOn = DateTime.UtcNow;
    }

    public void PerformAutopartChange(Autopart autopart, IMoney laborCost)
    {
        _partsChanged.Add(autopart);
        TotalLaborCost.Add(laborCost);
    }
}
