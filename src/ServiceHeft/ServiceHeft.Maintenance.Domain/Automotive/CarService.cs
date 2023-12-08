using Serilog;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;
using ServiceHeft.Maintenance.Contracts.Common.ErrorHandling;
using ServiceHeft.Maintenance.Contracts.Common.Persistence;

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

    public Task DecommissionAsnyc(Guid carId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(DeleteCarRequest request)
    {
        await _repository.DeleteAsync(request.CarId);

        _logger.Information("A car with ID '{Id}' was deleted", request.CarId);
    }

    public async Task<GetCarByIdResponse?> GetByIdAsync(GetCarByIdRequest request)
    {
        // TODO: implement null pattern instead of returning null
        var car = await _repository.FindAsync(request.CarId);

        if (car == null)
        {
            return default;
        };

        return new GetCarByIdResponse
        {
            Id = car.Id,
            Engine = car.Engine,
            ModelInfo = car.ModelInfo,
            Vin = car.Vin,
            DistanceDrivenInKilometers = car.DistanceDrivenInKilometers,
            LicencePlate = car.LicencePlate,
            ProducedOn = car.ProducedOn
        };
    }

    public async Task UpdateAsync(UpdateCarRequest request)
    {
        // TODO: do validation

        var storedCar = await _repository.FindAsync(request.CarId);

        if (storedCar == null)
        {
            throw new NotFoundException($"The car with ID '{request.CarId}' does not exist.");
        }

        storedCar.UpdateInformation(request.Engine, request.LicencePlate, request.DistanceDrivenInKilometers);

        await _repository.UpdateAsync(storedCar);

        _logger.Information("Updated car: {CarId}", storedCar.Id);
    }
}
