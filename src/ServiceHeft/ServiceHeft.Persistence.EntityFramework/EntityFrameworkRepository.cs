using Microsoft.EntityFrameworkCore;
using ServiceHeft.Maintenance.Contracts.Common;

namespace ServiceHeft.Persistence.EntityFramework;

public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbContext _dbContext;

    public EntityFrameworkRepository(DbContext dbContext)
    {
        this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<Guid> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> FindAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
