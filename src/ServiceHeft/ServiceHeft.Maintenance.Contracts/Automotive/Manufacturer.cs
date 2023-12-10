namespace ServiceHeft.Maintenance.Contracts.Automotive;

public record Manufacturer
{
    public string Name { get; private set; }

    private Manufacturer()
    {
        Name = string.Empty;
    }

    public Manufacturer(string name)
    {
        Name = name;
    }
}
