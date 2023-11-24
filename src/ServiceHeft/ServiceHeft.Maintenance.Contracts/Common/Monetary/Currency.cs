namespace ServiceHeft.Maintenance.Contracts.Common.Monetary;

public record Currency(string Name)
{
    public static Currency NoCurrency => new Currency(string.Empty);
}