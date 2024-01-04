using System.Linq.Expressions;
using MongoDB.Driver;

namespace IdekuDoku.Domain.Mongo.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly IMongoCollection<TEntity> _collection;

    public GenericRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public async Task<TEntity> GetByIdAsync(string id)
    {
        return await _collection.Find(Builders<TEntity>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, TEntity entity)
    {
        await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
    }
}