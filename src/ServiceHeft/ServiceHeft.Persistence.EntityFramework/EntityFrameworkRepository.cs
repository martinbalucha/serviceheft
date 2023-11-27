using Microsoft.EntityFrameworkCore;
using ServiceHeft.Maintenance.Contracts.Common;
using ServiceHeft.Maintenance.Contracts.Common.ErrorHandling;

namespace ServiceHeft.Persistence.EntityFramework;

public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbContext _dbContext;

    public EntityFrameworkRepository(DbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbContext.FindAsync<TEntity>(id);

        if (entity is null)
        {
            throw new NotFoundException($"The object of type '{typeof(TEntity).Name}' with ID '{id}' does not exist.");
        }

        _dbContext.Remove(entity);
    }

    public async Task<TEntity?> FindAsync(Guid id)
    {
        return await _dbContext.FindAsync<TEntity>(id);
    }

    public Task<IEnumerable<TEntity>> ListAsync()
    {
        var entities = _dbContext.Set<TEntity>().AsEnumerable();
        return Task.FromResult(entities);
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
