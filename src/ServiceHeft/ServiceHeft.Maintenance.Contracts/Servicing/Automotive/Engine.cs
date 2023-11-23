namespace ServiceHeft.Maintenance.Contracts.Servicing.Automotive;

public class Engine : Entity
{
    public string Name { get; set; }
    public FuelType FuelType { get; set; }
    public int CylinderVolumeInCubicCentimeters { get; set; }
    public int PowerInKilowatts { get; set; }

    public Engine(Guid id, 
        string name, 
        FuelType fuelType, 
        int powerInKilowatts, 
        int cylinderVolumeInCubicCentimeters) : base(id)
    {
        Name = name;
        FuelType = fuelType;
        PowerInKilowatts = powerInKilowatts;
        CylinderVolumeInCubicCentimeters = cylinderVolumeInCubicCentimeters;
    }
}
