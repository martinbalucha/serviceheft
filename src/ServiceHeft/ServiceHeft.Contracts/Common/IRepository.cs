namespace ServiceHeft.Contracts.Common;

/// <summary>
/// Provides CRUD operations on a specified <typeparamref name="TEntity"/>
/// </summary>
/// <typeparam name="TEntity">A domain entity the repository will work with.</typeparam>
public interface IRepository<TEntity> where TEntity : Entity
{
    Task<Guid> CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task<TEntity?> FindAsync(Guid id);
    Task<IEnumerable<TEntity>> ListAsync();
}
