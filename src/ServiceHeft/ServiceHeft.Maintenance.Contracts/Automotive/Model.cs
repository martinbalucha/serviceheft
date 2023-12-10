namespace ServiceHeft.Maintenance.Contracts.Automotive;

public record Model
{
    public string Manufacturer { get; private set; } = string.Empty;
    public string OfficialName { get; private set; } = string.Empty;
    public string? InternalName { get; private set; }

    private Model()
    {
    }

    public Model(string manufacturer, string officialName, string? internalName = null)
    {
        Manufacturer = manufacturer;
        OfficialName = officialName;
        InternalName = internalName;
    }
}