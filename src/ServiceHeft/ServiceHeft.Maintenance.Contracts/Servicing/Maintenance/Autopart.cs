using ServiceHeft.Maintenance.Contracts.Servicing.Common;

namespace ServiceHeft.Maintenance.Contracts.Servicing.Maintenance;

public class Autopart : Entity
{
    public string Name { get; set; }
    public string OemCode { get; set; }
    public string Producer { get; set; }
    public IMoney Price { get; set; }

    public Autopart(Guid id, string name, string oemCode, string producer, IMoney price) : base(id)
    {
        Name = name;
        OemCode = oemCode;
        Producer = producer;
        Price = price;
    }
}
