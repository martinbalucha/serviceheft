namespace ServiceHeft.Persistence.EntityFramework.DataSeeding;

public interface ISeedingDataRepositoryFactory
{
    ISeedingDataRepository<T> Create<T>() where T : class;
}