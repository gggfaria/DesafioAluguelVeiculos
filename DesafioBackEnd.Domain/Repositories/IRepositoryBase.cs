using System.Linq.Expressions;
using DesafioBackEnd.Domain.Entities;

namespace DesafioBackEnd.Domain.Repositories;

public interface IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    Task<TEntity> GetAsync(Guid id, bool asNoTracking = true);
    Task<IEnumerable<TEntity>> GetAllAsync(int skip = 0, int limit = int.MaxValue);

    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);

    int Count();
    Task<int> CountAsync();

    Task<bool> EntityExists(Expression<Func<TEntity, bool>> filter);

    bool Commit();
    Task<bool> CommitAsync();
}