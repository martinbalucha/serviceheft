using ServiceHeft.Contracts.Servicing.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Contracts.Servicing.Automotive;

public class Car : Entity
{
    private readonly List<ServiceRecord> serviceRecords = new();

    public string Vin { get; init; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public DateTime ProducedOn { get;init;}
    public Engine Engine { get; set; }    
    public IReadOnlyList<ServiceRecord> ServiceRecords => serviceRecords;

    public Car(Guid id) : base(id)
    {
    }
}
