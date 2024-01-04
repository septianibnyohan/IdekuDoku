namespace IdekuDoku.Domain.Mongo.UnitOfWork;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
    void BeginTransaction();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}