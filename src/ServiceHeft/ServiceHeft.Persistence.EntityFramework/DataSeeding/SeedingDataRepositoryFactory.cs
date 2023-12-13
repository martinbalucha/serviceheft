using Microsoft.Extensions.Configuration;
using System.IO.Abstractions;

namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public class SeedingDataRepositoryFactory : ISeedingDataRepositoryFactory
{
    private const string DataSeedingSectionName = "DataSeeding";

    private readonly IFile _file;
    private readonly IConfiguration _configuration;

    public SeedingDataRepositoryFactory(IFile file, IConfiguration configuration)
    {
        _file = file ?? throw new ArgumentNullException(nameof(file));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public ISeedingDataRepository<T> Create<T>() where T : class
    {
        var dataSeedingConfiguration = GetSeedingConfigurationForType<T>();

        CheckIfConfigurationIsValid(dataSeedingConfiguration);

        return new SeedingDataRepository<T>(_file, dataSeedingConfiguration);
    }

    private DataSeedingConfiguration? GetSeedingConfigurationForType<T>()
    {
        var typeSeedingConfiguration = _configuration.GetSection(DataSeedingSectionName).GetSection(typeof(T).Name);

        var configuration = typeSeedingConfiguration.GetSection(nameof(DataSeedingConfiguration)).Get<DataSeedingConfiguration>();
        
        return configuration;
    }

    private static void CheckIfConfigurationIsValid(DataSeedingConfiguration? dataSeedingConfiguration)
    {
        if (dataSeedingConfiguration is null)
        {
            throw new ArgumentException("Invalid configuration for data seeding.");
        }
        if (string.IsNullOrWhiteSpace(dataSeedingConfiguration.SeedingFilePath))
        {
            throw new ArgumentException($"The property '{nameof(dataSeedingConfiguration.SeedingFilePath)}' cannot be empty or whitespace.");
        }
    }
}
