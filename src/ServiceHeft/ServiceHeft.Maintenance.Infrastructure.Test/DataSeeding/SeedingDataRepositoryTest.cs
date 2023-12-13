using FluentAssertions;
using Moq;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;
using System.IO.Abstractions;
using System.Text.Json;
using Xunit;

namespace ServiceHeft.Maintenance.Infrastructure.Test.DataSeeding;

public class SeedingDataRepositoryTest
{
    private readonly Mock<IFile> _file = new();
    private readonly DataSeedingConfiguration _dataSeedingConfiguration;
    private readonly SeedingDataRepository<Model> _repository;

    public SeedingDataRepositoryTest()
    {
        _dataSeedingConfiguration = new DataSeedingConfiguration() 
        {
            SeedingFilePath = "models.json" 
        };

        _repository = new SeedingDataRepository<Model>(_file.Object, _dataSeedingConfiguration);
    }

    [Fact]
    public void Read_ExistingData_CorrectCollectionReturned()
    {
        // Arrange
        var storedData = new Model[]
        {
            new Model("Citroen", "C5", "X7"),
            new Model("Opel", "Vectra", "B"),
            new Model("Škoda", "Felicia")
        };

        var dataInJson = JsonSerializer.Serialize(storedData);

        _file.Setup(f => f.ReadAllText(_dataSeedingConfiguration.SeedingFilePath)).Returns(dataInJson);

        // Act
        var result = _repository.Read();

        // Assert
        result.Should().BeEquivalentTo(storedData);
    }

    [Fact]
    public async Task ReadAsync_ExistingData_CorrectCollectionReturned()
    {
        // Arrange
        var storedData = new Model[]
        {
            new Model("Citroen", "C5", "X7"),
            new Model("Opel", "Vectra", "B"),
            new Model("Škoda", "Felicia")
        };

        var dataInJson = JsonSerializer.Serialize(storedData);

        _file.Setup(f => f.ReadAllTextAsync(_dataSeedingConfiguration.SeedingFilePath, CancellationToken.None)).ReturnsAsync(dataInJson);

        // Act
        var result = await _repository.ReadAsync();

        // Assert
        result.Should().BeEquivalentTo(storedData);
    }

    [Fact]
    public void Read_NoDataStored_EmptyCollectionReturned()
    {
        // Arrange
        var storedData = Enumerable.Empty<Model>();

        var dataInJson = JsonSerializer.Serialize(storedData);

        _file.Setup(f => f.ReadAllText(_dataSeedingConfiguration.SeedingFilePath)).Returns(dataInJson);

        // Act
        var result = _repository.Read();

        // Assert
        result.Should().BeEquivalentTo(storedData);
    }

    [Fact]
    public async Task ReadAsync_OperationCancelled_ExceptionThrown()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act & Assert
        await Assert.ThrowsAsync<OperationCanceledException>(() => _repository.ReadAsync(cancellationTokenSource.Token));
    }
}
