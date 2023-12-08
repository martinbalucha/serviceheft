using Moq;
using Serilog;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Automotive.Dtos;
using ServiceHeft.Maintenance.Contracts.Common.Persistence;
using ServiceHeft.Maintenance.Domain.Automotive;
using Xunit;

namespace ServiceHeft.Maintenance.Domain.Test;

public class CarServiceTest
{
    private readonly Mock<IRepository<Car>> _repository = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
    private readonly CarService _carService;

    public CarServiceTest()
    {
        var logger = new Mock<ILogger>();
        _carService = new CarService(_repository.Object, _unitOfWork.Object, logger.Object);
    }

    [Fact]
    public async Task CreateAsync_ValidRequest_CarCreated()
    {
        // Arrange
        var request = new CreateCarRequest
        {
            ModelInfo = new Model(new Manufacturer("Citroen"), "C5", "X7"),
            DistanceDrivenInKilometers = 193000,
            Engine = new Engine("RWR", FuelType.Diesel, 1997, 120),
            LicencePlate = "2AB0373",
            Vin = "VF712345678912345",
            ProducedOn = DateTime.Now
        };

        // Act
        var result = await _carService.CreateAsync(request);

        // Assert
        Assert.NotEqual(default, result.CarId);
        _repository.Verify(r => r.CreateAsync(It.Is<Car>(c => c.Id == result.CarId
                                                        && c.DistanceDrivenInKilometers == request.DistanceDrivenInKilometers
                                                        && c.LicencePlate == request.LicencePlate 
                                                        && c.Model == request.ModelInfo 
                                                        && c.Engine == request.Engine)));
    }

    [Fact]
    public async Task DeleteAsync_ExistingCar_CarDeleted()
    {
        // Arrange
        var carId = Guid.NewGuid();

        // Act
        await _carService.DeleteAsync(new DeleteCarRequest(carId));

        // Assert
        _repository.Verify(r => r.DeleteAsync(carId));
    }
}
