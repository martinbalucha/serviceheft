using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

namespace ServiceHeft.Maintenance.Contracts.Automotive;

public interface ICarService
{
    Task<CreateCarResponse> CreateAsync(CreateCarRequest request);
    Task UpdateAsync(Car car);
    Task DecommissionAsnyc(Guid carId);
    Task DeleteAsync(Guid carId);
    Task<Car> FindAsync(Guid carId);
}
