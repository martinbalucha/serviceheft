﻿namespace ServiceHeft.Contracts.Servicing.Automotive;

public record Engine
{
    public string Name { get; set; }
    public FuelType FuelType { get; set; }
    public int CylinderVolumeInCubicCentimeters { get; set; }
    public int PowerInKilowatts { get; set; }

    public Engine(string name, FuelType fuelType, 
        int powerInKilowatts, int cylinderVolumeInCubicCentimeters)
    {
        Name = name;
        FuelType = fuelType;
        PowerInKilowatts = powerInKilowatts;
        CylinderVolumeInCubicCentimeters = cylinderVolumeInCubicCentimeters;
    }
}
