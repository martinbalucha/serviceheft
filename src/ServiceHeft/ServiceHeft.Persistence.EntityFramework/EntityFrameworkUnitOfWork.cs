using ServiceHeft.Maintenance.Contracts.Common.Persistence;
using ServiceHeft.Persistence.EntityFramework.DataAccess;

namespace ServiceHeft.Persistence.EntityFramework;

public sealed class EntityFrameworkUnitOfWork : IUnitOfWork
{
    private readonly ServiceHeftDbContext _dbContext;
    
    public EntityFrameworkUnitOfWork(ServiceHeftDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
