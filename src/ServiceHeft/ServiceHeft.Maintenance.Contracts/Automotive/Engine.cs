namespace ServiceHeft.Maintenance.Contracts.Automotive;

public record Engine(string Name, FuelType FuelType, int CylinderVolumeInCubicCentimeters, int PowerInKilowatts);