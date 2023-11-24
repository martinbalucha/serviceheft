using ServiceHeft.Maintenance.Contracts.Common;
using ServiceHeft.Maintenance.Contracts.Common.Monetary;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceHeft.Maintenance.Contracts.Maintenance;

public class Autopart : Entity
{
    public string Name { get; set; }
    public string OemCode { get; set; }
    public string Producer { get; set; }

    [NotMapped]
    public IMoney Price { get; set; }

    private Autopart() : base(Guid.Empty)
    {
    }

    public Autopart(Guid id, string name, string oemCode, string producer, IMoney price) : base(id)
    {
        Name = name;
        OemCode = oemCode;
        Producer = producer;
        Price = price;
    }
}
