namespace ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

public sealed record CreateCarRequest
{
    public required string Vin { get; init; }
    public required Model ModelInfo { get; init; }
    public DateTime ProducedOn { get; init; }
    public string? LicencePlate { get; init; }
    public int DistanceDrivenInKilometers { get; init; }
    public required Engine Engine { get; init; }
}
