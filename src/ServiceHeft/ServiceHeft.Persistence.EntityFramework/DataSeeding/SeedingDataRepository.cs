using Microsoft.Extensions.Options;
using System.IO.Abstractions;
using System.Runtime.Serialization;
using System.Text.Json;

namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public class SeedingDataRepository<T> : ISeedingDataRepository<T> where T : class
{
    private readonly IFile _file;
    private readonly DataSeedingConfiguration _dataSeedingConfiguration;

    public SeedingDataRepository(IFile file, IOptions<DataSeedingConfiguration> dataSeedingConfiguration)
    {
        _file = file ?? throw new ArgumentNullException(nameof(file));

        ArgumentNullException.ThrowIfNull(dataSeedingConfiguration);
        _dataSeedingConfiguration = dataSeedingConfiguration.Value;
    }

    public IEnumerable<T> Read()
    {
        string jsonString = _file.ReadAllText(_dataSeedingConfiguration.SeedingFilePath);

        var data = JsonSerializer.Deserialize<List<T>>(jsonString)
            ?? throw new SerializationException("An error occurred during the file deserialization.");

        return data;
    }

    public async Task<IEnumerable<T>> ReadAsync()
    {
        string jsonString = await _file.ReadAllTextAsync(_dataSeedingConfiguration.SeedingFilePath);

        var data = JsonSerializer.Deserialize<List<T>>(jsonString)
            ?? throw new SerializationException("An error occurred during the file deserialization.");

        return data;
    }
}
