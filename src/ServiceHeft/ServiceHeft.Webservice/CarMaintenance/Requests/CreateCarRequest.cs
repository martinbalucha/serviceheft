namespace ServiceHeft.Webservice.CarMaintenance.Requests;

public record CreateCarRequest
{
    public string Vin { get; init; } = string.Empty;
    public string LicencePlate { get; init; } = string.Empty;
}
