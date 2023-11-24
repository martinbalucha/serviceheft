namespace ServiceHeft.Maintenance.Contracts.Common.Monetary;

public interface IMoney : IComparable<IMoney>
{
    IMoney Add(IMoney money);
    IMoney Subtract(IMoney money);
}
