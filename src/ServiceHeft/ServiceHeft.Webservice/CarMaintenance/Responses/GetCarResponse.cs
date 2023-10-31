namespace ServiceHeft.Webservice.CarMaintenance.Responses;

public record GetCarResponse
{
    public Guid Id { get; init; }
    public string Vin { get; init; }
    public string LicencePlate { get; init; }
}
