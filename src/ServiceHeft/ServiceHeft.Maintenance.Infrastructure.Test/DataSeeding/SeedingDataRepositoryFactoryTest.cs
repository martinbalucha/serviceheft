using Moq;
using ServiceHeft.Maintenance.Contracts.Automotive;
using ServiceHeft.Maintenance.Infrastructure.Test.Utils;
using ServiceHeft.Persistence.EntityFramework.DataSeeding;
using System.IO.Abstractions;
using Xunit;

namespace ServiceHeft.Maintenance.Infrastructure.Test.DataSeeding;

public class SeedingDataRepositoryFactoryTest
{
    private readonly Mock<IFile> _file = new();

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

        var seedingDataRepositoryFactory = new SeedingDataRepositoryFactory(_file.Object, configuration);

        // Act
        var repository = seedingDataRepositoryFactory.Create<Model>();

        // Assert
        Assert.IsType<SeedingDataRepository<Model>>(repository);
    }

    [Fact]
    public void Create_EmptyFilePath_ExceptionThrown()
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
                        SeedingFilePath = string.Empty
                    }
                }
            }
        };

        var configuration = TestConfigurationBuilder.Build(appSettings);

        var seedingDataRepositoryFactory = new SeedingDataRepositoryFactory(_file.Object, configuration);

        // Act & Assert
        Assert.Throws<ArgumentException>(seedingDataRepositoryFactory.Create<Model>);
    }

    [Fact]
    public void Create_MissingDataSeedingConfigurationSection_ExceptionThrown()
    {
        // Arrange
        var appSettings = new
        {
            DataSeeding = new
            {
                Model = new
                {
                }
            }
        };

        var configuration = TestConfigurationBuilder.Build(appSettings);

        var seedingDataRepositoryFactory = new SeedingDataRepositoryFactory(_file.Object, configuration);

        // Act & Assert
        Assert.Throws<ArgumentException>(seedingDataRepositoryFactory.Create<Model>);
    }

    [Fact]
    public void Create_MissingEntityNameSection_ExceptionThrown()
    {
        // Arrange
        var appSettings = new
        {
            DataSeeding = new
            {
            }
        };

        var configuration = TestConfigurationBuilder.Build(appSettings);

        var seedingDataRepositoryFactory = new SeedingDataRepositoryFactory(_file.Object, configuration);

        // Act & Assert
        Assert.Throws<ArgumentException>(seedingDataRepositoryFactory.Create<Model>);
    }
}
