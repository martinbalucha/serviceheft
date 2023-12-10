namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public record DataSeedingConfiguration
{
    public string SeedingFilePath { get; init; } = string.Empty;
}
