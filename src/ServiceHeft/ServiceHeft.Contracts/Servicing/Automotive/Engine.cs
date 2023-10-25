using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Contracts.Servicing.Automotive;

public class Engine
{
    public FuelType FuelTypeFuelType { get; set; }
    public int CylinderVolumeInCubicCentimeters { get; set; }
}
