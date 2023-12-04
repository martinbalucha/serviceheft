using Serilog;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;
using ServiceHeft.Maintenance.Contracts.Common;

namespace ServiceHeft.Maintenance.Domain.Automotive;

public class CarService : ICarService
{
    private readonly IRepository<Car> _repository;
    private readonly ILogger _logger;

    public CarService(IRepository<Car> repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<CreateCarResponse> CreateAsync(CreateCarRequest request)
    {
        // TODO: validate here

        var car = new Car(Guid.NewGuid(), request.Vin, request.ModelInfo, request.ProducedOn, 
                            request.LicencePlate, request.DistanceDrivenInKilometers, request.Engine);

        await _repository.CreateAsync(car);

        _logger.Information("A car with ID '{Id}' successfully created.", car.Id);

        return new CreateCarResponse(car.Id);
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
