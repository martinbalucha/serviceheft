namespace ServiceHeft.Maintenance.Contracts.Common;

/// <summary>
/// Provides CRUD operations on a specified <typeparamref name="TEntity"/>
/// </summary>
/// <typeparam name="TEntity">A domain entity the repository will work with.</typeparam>
public interface IRepository<TEntity> where TEntity : Entity
{
    Task CreateAsync(TEntity entity);

    /// <summary></summary>
    /// <param name="entity"></param>
    /// <exception cref="NotFoundException">When the updated entity does not exist in the data storage.</exception>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
    Task<TEntity?> FindAsync(Guid id);
    Task<IEnumerable<TEntity>> ListAsync();
}
