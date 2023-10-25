using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Contracts.Servicing.Maintenance;

public class Autopart : Entity
{
    public string Name { get; set; }
    public string OemCode { get; set; }
    public string Producer { get; set; }
    public IMoney Price { get; set; }

    public Autopart(Guid id) : base(id)
    {
    }
}
