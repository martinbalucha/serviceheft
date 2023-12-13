namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public record DataSeedingConfiguration
{
    public required string SeedingFilePath { get; init; }
}
