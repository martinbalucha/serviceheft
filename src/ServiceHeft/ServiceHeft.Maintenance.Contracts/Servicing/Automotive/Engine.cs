namespace ServiceHeft.Maintenance.Contracts.Servicing.Automotive;

public record Engine(string Name, FuelType FuelType, int CylinderVolumeInCubicCentimeters, int PowerInKilowatts);