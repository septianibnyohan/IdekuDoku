using System.Linq.Expressions;

namespace IdekuDoku.Domain.Mongo.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(string id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(string id, TEntity entity);
    Task DeleteAsync(string id);
}