﻿using ServiceHeft.Contracts.Servicing.Maintenance;

namespace ServiceHeft.Contracts.Servicing.Automotive;

public class Car : Entity
{
    private readonly List<ServiceRecord> serviceRecords = new();

    public Car(Guid id, List<ServiceRecord> serviceRecords, string vin, ModelInfo modelInfo, 
        DateTime producedOn, string licencePlate, int distanceDrivenInKilometers, Engine engine) : base(id)
    {
        Vin = vin;
        ModelInfo = modelInfo;
        ProducedOn = producedOn;
        LicencePlate = licencePlate;
        DistanceDrivenInKilometers = distanceDrivenInKilometers;
        Engine = engine;
        this.serviceRecords = serviceRecords;
    }

    public string Vin { get; set; }
    public ModelInfo ModelInfo { get; set; }
    public DateTime ProducedOn { get; init;}
    public string LicencePlate { get; set; }
    public int DistanceDrivenInKilometers { get; set; }    
    public Engine Engine { get; set; }    
    public IReadOnlyList<ServiceRecord> ServiceRecords => serviceRecords;
}
