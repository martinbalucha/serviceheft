using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

namespace ServiceHeft.Maintenance.Contracts.Automotive;

public interface ICarService
{
    Task<CreateCarResponse> CreateAsync(CreateCarRequest request);
    Task UpdateAsync(UpdateCarRequest request);
    Task DecommissionAsnyc(Guid carId);
    Task DeleteAsync(DeleteCarRequest request);
    Task<Car?> GetByIdAsync(GetCarByIdRequest request);
}
