namespace ServiceHeft.Maintenance.Contracts.Automotive.Dtos;

public sealed record UpdateCarRequest
{
    public Guid CarId { get; init; }
    public required string LicencePlate { get; init; }
    public int DistanceDrivenInKilometers { get; init; }
    public required Engine Engine { get; init; }
}
