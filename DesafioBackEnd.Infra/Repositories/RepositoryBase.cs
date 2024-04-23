using System.Linq.Expressions;
using DesafioBackEnd.Domain.Entities;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.Infra.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected readonly DesafioContext _context;

    public RepositoryBase(DesafioContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync(Guid id, bool asNoTracking)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

        if (asNoTracking) query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(e => e.Id.Equals(id));
    }


    public async Task<IEnumerable<TEntity>> GetAllAsync(int skip = 0, int limit = int.MaxValue)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .Skip(skip)
            .Take(limit)
            .OrderBy(c => c.CreationDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>()
            .AsNoTracking()
            .Where(filter)
            .OrderBy(c => c.CreationDate)
            .ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
    }

    public int Count()
    {
        return _context.Set<TEntity>().Count();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().AsNoTracking().CountAsync();
    }


    public async Task<bool> EntityExists(Expression<Func<TEntity, bool>> filter)
    {
        bool entityExists = await _context.Set<TEntity>()
            .AsNoTracking()
            .AnyAsync(filter);

        return entityExists;
    }
    
    public virtual void Update(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _context.Set<TEntity>().Attach(entity);

        _context.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _context.Set<TEntity>().Attach(entity);

        _context.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
    }


    public bool Commit()
    {
        var numberEntriesSaved = _context.SaveChanges();
        return numberEntriesSaved > 0;
    }

    public async Task<bool> CommitAsync()
    {
        var numberEntriesSaved = await _context.SaveChangesAsync();
        return numberEntriesSaved > 0;
    }
}