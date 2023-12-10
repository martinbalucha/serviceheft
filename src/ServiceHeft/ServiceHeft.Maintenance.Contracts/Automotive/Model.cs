namespace ServiceHeft.Maintenance.Contracts.Automotive;

public record Model
{
    public Manufacturer Manufacturer { get; private set; }
    public string OfficialName { get; private set; }
    public string? InternalName { get; private set; }

    private Model()
    {
    }

    public Model(Manufacturer manufacturer, string officialName, string? internalName = null)
    {
        Manufacturer = manufacturer;
        OfficialName = officialName;
        InternalName = internalName;
    }
}