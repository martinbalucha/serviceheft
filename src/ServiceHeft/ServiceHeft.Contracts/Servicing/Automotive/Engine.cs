namespace ServiceHeft.Contracts.Servicing.Automotive;

public record Engine
{
    public string Name { get; set; }
    public FuelType FuelTypeFuelType { get; set; }
    public int CylinderVolumeInCubicCentimeters { get; set; }
    public int PowerInKilowatts { get; set; }
}
