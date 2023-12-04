using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

namespace ServiceHeft.Maintenance.Contracts.Automotive;

public interface ICarService
{
    Task<CreateCarResponse> CreateAsync(CreateCarRequest request);
    Task UpdateAsync(Car car);
    Task DecommissionAsnyc(Guid car);
    Task DeleteAsync(Car car);
    Task<Car> FindAsync(Guid guid);
}
