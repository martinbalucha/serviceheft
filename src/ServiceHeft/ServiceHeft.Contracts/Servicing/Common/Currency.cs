namespace ServiceHeft.Contracts.Servicing.Common;

public record Currency(string Name)
{
    public static Currency NoCurrency => new Currency(string.Empty);
}