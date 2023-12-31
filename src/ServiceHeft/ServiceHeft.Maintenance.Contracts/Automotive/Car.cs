﻿using ServiceHeft.Maintenance.Contracts.Common;
using ServiceHeft.Maintenance.Contracts.Maintenance;

namespace ServiceHeft.Maintenance.Contracts.Automotive;

public class Car : Entity
{
    private readonly List<ServiceRecord> serviceRecords = new();

    /// <summary>
    /// Vehicle Identification Number
    /// </summary>
    public string Vin { get; private set; }
    public Model Model { get; private set; }
    public DateTime ProducedOn { get; init; }
    public string LicencePlate { get; set; }
    public int DistanceDrivenInKilometers { get; set; }
    public Engine Engine { get; set; }
    public IReadOnlyList<ServiceRecord> ServiceRecords => serviceRecords;

    private Car() : base(Guid.Empty)
    {
    }

    public Car(Guid id, string vin, Model modelInfo,
        DateTime producedOn, string licencePlate,
        int distanceDrivenInKilometers, Engine engine) : base(id)
    {
        Vin = vin;
        Model = modelInfo;
        ProducedOn = producedOn;
        LicencePlate = licencePlate;
        DistanceDrivenInKilometers = distanceDrivenInKilometers;
        Engine = engine;
    }

    public void UpdateInformation(Engine engine, string licencePlate, int distanceDriven)
    {
        ArgumentNullException.ThrowIfNull(nameof(engine));

        Engine = engine;
        LicencePlate = licencePlate.Trim().ToUpper();
        DistanceDrivenInKilometers = distanceDriven;
    }
}
