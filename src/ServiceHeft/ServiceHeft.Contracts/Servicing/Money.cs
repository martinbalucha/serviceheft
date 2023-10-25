using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHeft.Contracts.Servicing;

public record Money : IMoney, IComparable<Money>
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    public Money(decimal amount, Currency currency)
    {
        CheckIfAmountIsNotNegative(amount);

        Amount = amount; 
        Currency = currency;
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

    private static void CheckIfAmountIsNotNegative(decimal amount)
    {
        if (amount < 0)
        {
            throw new InvalidOperationException("The amount of money cannot be negative.");
        }
    }
}
