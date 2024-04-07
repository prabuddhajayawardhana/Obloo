using System.Linq.Expressions;

namespace Obloo.Domain.Interfaces;

public interface IRepository<T>
{
    int Count();
    T GetById(int id);
    Task<T> GetByIdAsync(int id);
    T Get(Expression<Func<T, bool>> predicate);
    IList<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllAsync();
    void Add(T entity);
    void Remove(T entity);
}