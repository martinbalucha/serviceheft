using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
}