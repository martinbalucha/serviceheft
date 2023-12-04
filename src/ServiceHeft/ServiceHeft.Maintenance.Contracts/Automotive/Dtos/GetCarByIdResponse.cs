namespace ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

public sealed record GetCarByIdResponse
{
    public Guid Id { get; init; }
    public required string Vin { get; init; }
    public required ModelInfo ModelInfo { get; init; }
    public DateTime ProducedOn { get; init; }
    public string? LicencePlate { get; init; }
    public int DistanceDrivenInKilometers { get; set; }
    public required Engine Engine { get; init; }
}
