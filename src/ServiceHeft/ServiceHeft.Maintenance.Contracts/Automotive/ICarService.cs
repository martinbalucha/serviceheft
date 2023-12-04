namespace ServiceHeft.Maintenance.Contracts.Automotive;

public interface ICarService
{
    Task CreateAsync(Car car);
    Task UpdateAsync(Car car);
    Task DecommissionAsnyc(Guid car);
    Task DeleteAsync(Car car);
    Task<Car> FindAsync(Guid guid);
}
