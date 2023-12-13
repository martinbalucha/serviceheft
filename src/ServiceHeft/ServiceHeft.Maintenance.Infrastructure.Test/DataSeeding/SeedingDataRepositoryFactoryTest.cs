using Moq;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Infrastructure.Test.Utils;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;
using System.IO.Abstractions;
using Xunit;

namespace ServiceHeft.Maintenance.Infrastructure.Test.DataSeeding;

public class SeedingDataRepositoryFactoryTest
{
    private readonly Mock<IFile> file = new();

    [Fact]
    public void Create_ValidConfiguration_RepositoryCreated()
    {
        // Arrange
        var appSettings = new
        {
            DataSeeding = new
            {
                Model = new
                {
                    DataSeedingConfiguration = new
                    {
                        SeedingFilePath = "seedingFile"
                    }
                }
            }
        };

        var configuration = TestConfigurationBuilder.Build(appSettings);

        var seedingDataRepositoryFactory = new SeedingDataRepositoryFactory(file.Object, configuration);

        // Act
        var repository = seedingDataRepositoryFactory.Create<Model>();

        // Assert
        Assert.IsType<SeedingDataRepository<Model>>(repository);
    }
}
