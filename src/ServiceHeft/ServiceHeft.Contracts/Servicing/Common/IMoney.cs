namespace ServiceHeft.Contracts.Servicing.Common;

public interface IMoney : IComparable<IMoney>
{
    IMoney Add(IMoney money);
    IMoney Subtract(IMoney money);
}
