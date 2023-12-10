namespace ServiceHeft.Persistence.EntityFramework.Configuration;

public record DataSeedingConfiguration
{
    public string SeedingFilePath { get; init; } = string.Empty;
}
