using ServiceHeft.Contracts.Servicing.Common;

namespace ServiceHeft.Contracts.Servicing.Maintenance;

public class ServiceRecord : Entity
{
    private readonly List<Autopart> partsChanged = new ();

    public Guid CarId { get; set; }
    public DateTime HappenedOn { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IMoney LaborCost { get; set; }
    public IReadOnlyList<Autopart> PartsChanged => partsChanged;

    public IMoney TotalCost => LaborCost;

    public ServiceRecord(Guid id, Guid carId, DateTime happenedOn, string name, string description, IMoney laborCost) : base(id)
    {
        CarId = carId;
        Name = name;
        Description = description;
        LaborCost = laborCost;
    }
}
