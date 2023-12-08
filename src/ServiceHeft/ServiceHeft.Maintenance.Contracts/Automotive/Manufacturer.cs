namespace ServiceHeft.Maintenance.Contracts.Automotive;

public class Manufacturer
{
    public string Name { get; private set; }

    public Manufacturer(string name)
    {
        Name = name;
    }
}
