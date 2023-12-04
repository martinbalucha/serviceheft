using ServiceHeft.Maintenance.Contracts.Automotive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Maintenance.Domain.Automotive;

public class CarService : ICarService
{
    public Task CreateAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task DecommissionAsnyc(Guid car)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<Car> FindAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Car car)
    {
        throw new NotImplementedException();
    }
}
