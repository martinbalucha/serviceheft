using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceHeft.Maintenance.Contracts.Automotive;
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
}