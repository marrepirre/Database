using FootballManager.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FootballManager.Repositories;

public interface IRepo<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAllAsync();
}


public abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity ?? null!;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        return entity ?? null!;
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().AnyAsync(expression);
    }
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return true; 
        }
        catch (Exception)
        {
            return false; 
        }

    }
    public virtual async Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
