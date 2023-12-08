namespace ServiceHeft.Maintenance.Contracts.Common.Persistence;

public interface IUnitOfWork : IDisposable
{
    Task SaveAsync();
}
