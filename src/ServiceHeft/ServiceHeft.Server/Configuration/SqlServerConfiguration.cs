namespace ServiceHeft.Server.Application.Configuration;

public record SqlServerConfiguration
{
    public int RetryOnFailureCount { get; init; }
    public int CommandTimeoutInSeconds { get; init; }
}
