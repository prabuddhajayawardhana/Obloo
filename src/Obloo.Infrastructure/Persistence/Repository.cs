using Microsoft.EntityFrameworkCore;
using Obloo.Domain.Interfaces;
using Obloo.Infrastructure.Persistence.Data;
using System.Linq.Expressions;

namespace Obloo.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly SqlDbContext _context;
    internal DbSet<T> _dbSet;

    public Repository(SqlDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id) ?? throw new Exception("Element not found");
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception("Element not found");
    }
    public T Get(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.FirstOrDefault(predicate) ?? throw new Exception("Element not found");
    }

    public IList<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public int Count()
    {
        return _dbSet.Count();
    }
}