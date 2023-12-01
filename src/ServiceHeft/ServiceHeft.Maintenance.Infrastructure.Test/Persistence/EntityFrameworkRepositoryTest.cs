using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Contracts.Common.ErrorHandling;
using ServiceHeft.Persistence.EntityFramework;
using Xunit;

namespace ServiceHeft.Maintenance.Infrastructure.Test.Persistence;

public class EntityFrameworkRepositoryTest
{
    private readonly Mock<DbContext> _dbContext = new Mock<DbContext>();
    private readonly EntityFrameworkRepository<Car> _repository;

    public EntityFrameworkRepositoryTest()
    {
        _repository = new EntityFrameworkRepository<Car>(_dbContext.Object);
    }

    [Fact]
    public async Task FindAsync_ExistingCar_CorrectCarReturned()
    {
        // Arrange
        var modelInfo = new ModelInfo("Citroen", "C5");
        var engine = new Engine("RHR", FuelType.Diesel, 1997, 120);
        var car = new Car(Guid.NewGuid(), "VF701234567891234", modelInfo, DateTime.Now, "2AB0373", 193000, engine);

        _dbContext.Setup(c => c.FindAsync<Car>(car.Id)).ReturnsAsync(car);

        // Act
        var result = await _repository.FindAsync(car.Id);

        // Assert
        result.Should().BeEquivalentTo(car);
    }

    [Fact]
    public async Task FindAsync_NonexistentCar_NullReturned()
    {
        // Act
        var result = await _repository.FindAsync(Guid.NewGuid());

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateAsync_ValidCar_CarCreated()
    {
        // Arrange
        var modelInfo = new ModelInfo("Citroen", "C5");
        var engine = new Engine("RHR", FuelType.Diesel, 1997, 120);
        var car = new Car(Guid.NewGuid(), "VF701234567891234", modelInfo, DateTime.Now, "2AB0373", 193000, engine);

        // Act
        await _repository.CreateAsync(car);

        // Assert
        _dbContext.Verify(c => c.AddAsync(car, default), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_NonexistentCar_ExceptionThrown()
    {
        // Arrange
        var modelInfo = new ModelInfo("Citroen", "C5");
        var engine = new Engine("RHR", FuelType.Diesel, 1997, 120);
        var car = new Car(Guid.NewGuid(), "VF701234567891234", modelInfo, DateTime.Now, "2AB0373", 193000, engine);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _repository.UpdateAsync(car));
        _dbContext.Verify(c => c.Update(It.IsAny<Car>), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_ExistingCar_CarUpdated()
    {
        // Arrange
        var modelInfo = new ModelInfo("Citroen", "C5");
        var engine = new Engine("RHR", FuelType.Diesel, 1997, 120);
        var storedCar = new Car(Guid.NewGuid(), "VF701234567891234", modelInfo, DateTime.Now, "2AB0373", 193000, engine);

        var updatedCar = new Car(storedCar.Id, storedCar.Vin, modelInfo, storedCar.ProducedOn, "2BM8421", 220000, engine);

        _dbContext.Setup(c => c.FindAsync<Car>(storedCar.Id)).ReturnsAsync(storedCar);

        // Act
        await _repository.UpdateAsync(updatedCar);

        // 
        _dbContext.Verify(c => c.FindAsync<Car>(storedCar.Id), Times.Once);
        _dbContext.Verify(c => c.Update(updatedCar), Times.Once);
    }

    [Fact]
    public async Task ListAsync_MultipleStoredCars_PopulatedCollectionReturned()
    {
        // Arrange
        var carsSet = new Mock<DbSet<Car>>();

        var storedCars = Enumerable.Empty<Car>().AsQueryable();

        carsSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(storedCars.Provider);
        carsSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(storedCars.Expression);
        carsSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(storedCars.ElementType);
        carsSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(storedCars.GetEnumerator);

        _dbContext.Setup(c => c.Set<Car>()).Returns(carsSet.Object);

        // Act
        var result = await _repository.ListAsync();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task ListAsync_NoStoredCars_EmptyCollectionReturned()
    {
        // Arrange
        var carsSet = new Mock<DbSet<Car>>();

        var storedCars = new List<Car>
        {
            new Car(Guid.NewGuid(), "VF701234567891234", new ModelInfo("Citroen", "C5"), DateTime.Now, "2AB0373", 193000, 
                    new Engine("2.0 HDI 163k", FuelType.Diesel, 1997, 120)),
            new Car(Guid.NewGuid(), "WBE01234567891234", new ModelInfo("BMW", "E46"), DateTime.Now, "2MA03479", 324000,
                    new Engine("M54", FuelType.Petrol, 2997, 170)),
            new Car(Guid.NewGuid(), "TEP01234567891234", new ModelInfo("Opel", "Insignia"), DateTime.Now, "2PT03479", 93000,
                    new Engine("Unbekannt", FuelType.Diesel, 1997, 133)),

        }.AsQueryable();

        carsSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(storedCars.Provider);
        carsSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(storedCars.Expression);
        carsSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(storedCars.ElementType);
        carsSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(storedCars.GetEnumerator);

        _dbContext.Setup(c => c.Set<Car>()).Returns(carsSet.Object);

        // Act
        var result = await _repository.ListAsync();

        // Assert
        result.Should().BeEquivalentTo(storedCars);
    }
}