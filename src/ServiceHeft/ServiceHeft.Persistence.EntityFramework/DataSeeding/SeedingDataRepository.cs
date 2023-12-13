using System.IO.Abstractions;
using System.Runtime.Serialization;
using System.Text.Json;

namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public class SeedingDataRepository<T> : ISeedingDataRepository<T> where T : class
{
    private readonly IFile _file;
    private readonly DataSeedingConfiguration _dataSeedingConfiguration;

    public SeedingDataRepository(IFile file, DataSeedingConfiguration dataSeedingConfiguration)
    {
        _file = file ?? throw new ArgumentNullException(nameof(file));
        _dataSeedingConfiguration = dataSeedingConfiguration ?? throw new ArgumentNullException(nameof(dataSeedingConfiguration));
    }

    public IEnumerable<T> Read()
    {
        string jsonString = _file.ReadAllText(_dataSeedingConfiguration.SeedingFilePath);

        return Deserialize(jsonString);
    }

    public async Task<IEnumerable<T>> ReadAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        string jsonString = await _file.ReadAllTextAsync(_dataSeedingConfiguration.SeedingFilePath);

        return Deserialize(jsonString);
    }

    private static IEnumerable<T> Deserialize(string jsonString)
    {
        var data = JsonSerializer.Deserialize<List<T>>(jsonString)
            ?? throw new SerializationException("An error occurred during the file deserialization.");

        return data;
    }
}
