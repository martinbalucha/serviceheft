using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Contracts.Servicing.Common;

public interface IMoney : IComparable<IMoney>
{
    IMoney Add(IMoney money);
    IMoney Subtract(IMoney money);
}
