namespace ServiceHeft.Server.Configuration;

public record SqlServerConfiguration
{
    public int RetryOnFailureCount { get; init; }
    public int CommandTimeoutInSeconds { get; init; }
}
