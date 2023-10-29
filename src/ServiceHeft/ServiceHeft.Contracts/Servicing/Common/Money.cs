namespace ServiceHeft.Contracts.Servicing.Common;

public record Money : IMoney, IComparable<Money>
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static IMoney? Create(decimal amount, Currency currency)
    {
        if (amount < 0)
        {
            return null;
        }


        return new Money(amount, currency);
    }

    public IMoney Add(IMoney money)
    {
        throw new NotImplementedException();
    }

    public IMoney Subtract(IMoney money)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Money? other)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(IMoney? other)
    {
        throw new NotImplementedException();
    }
}
