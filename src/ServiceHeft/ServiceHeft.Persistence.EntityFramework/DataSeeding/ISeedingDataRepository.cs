namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public interface ISeedingDataRepository<T> where T : class
{
    IEnumerable<T> Read();
    Task<IEnumerable<T>> ReadAsync(CancellationToken cancellationToken = default);
}
