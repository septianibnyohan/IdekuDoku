using IdekuDoku.Domain.Mongo.Repositories;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;
    private IClientSessionHandle _session;

    public UnitOfWork(IMongoClient mongoClient, string databaseName)
    {
        _mongoClient = mongoClient ?? throw new ArgumentNullException(nameof(mongoClient));
        _database = _mongoClient.GetDatabase(databaseName);
    }

    public void BeginTransaction()
    {
        if (_session != null)
            throw new InvalidOperationException("Transaction already started.");

        _session = _mongoClient.StartSession();
        _session.StartTransaction();
    }

    public async Task CommitTransactionAsync()
    {
        if (_session == null)
            throw new InvalidOperationException("No transaction to commit.");

        await _session.CommitTransactionAsync();
        _session.Dispose();
        _session = null;
    }

    public async Task RollbackTransactionAsync()
    {
        if (_session == null)
            throw new InvalidOperationException("No transaction to rollback.");

        await _session.AbortTransactionAsync();
        _session.Dispose();
        _session = null;
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            if (_session != null)
                await _session.CommitTransactionAsync();

            return true;
        }
        catch
        {
            if (_session != null)
                await _session.AbortTransactionAsync();

            return false;
        }
        finally
        {
            if (_session != null)
                _session.Dispose();
        }
    }

    // Add additional repository methods as needed...

    // Example of getting a repository
    /*
    public IBookRepository GetBookRepository()
    {
        return new BookRepository(_database);
    }

    // Example of getting an author repository
    public IAuthorRepository GetAuthorRepository()
    {
        return new AuthorRepository(_database);
    }
    */

    public IWebhookLogRepository GetWebhookLogRepository()
    {
        return new WebhookLogRepository(_database);
    }
}