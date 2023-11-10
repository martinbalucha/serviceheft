using ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Maintenance.Contracts.Servicing.Automotive;

public class Car : Entity
{
    private readonly List<ServiceRecord> serviceRecords = new();

    public string Vin { get; private set; }
    public ModelInfo ModelInfo { get; private set; }
    public DateTime ProducedOn { get; init; }
    public string LicencePlate { get; set; }
    public int DistanceDrivenInKilometers { get; set; }
    public Engine Engine { get; set; }
    public IReadOnlyList<ServiceRecord> ServiceRecords => serviceRecords;

    private Car() : base(Guid.Empty)
    {
    }

    public Car(Guid id, string vin, ModelInfo modelInfo, 
        DateTime producedOn, string licencePlate,
        int distanceDrivenInKilometers, Engine engine) : base(id)
    {
        Vin = vin;
        ModelInfo = modelInfo;
        ProducedOn = producedOn;
        LicencePlate = licencePlate;
        DistanceDrivenInKilometers = distanceDrivenInKilometers;
        Engine = engine;
    }
}
