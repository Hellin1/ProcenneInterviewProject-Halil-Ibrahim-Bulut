using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, bool trackChanges = true, CancellationToken cancellationToken = default);
    Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool trackChanges = true, CancellationToken cancellationToken = default);
    Task<TType?> GetByFilterAsync<TType>(Expression<Func<T, bool>> filter, Expression<Func<T, TType>> selector, bool trackChanges = true, CancellationToken cancellationToken = default) where TType : class;
    Task<List<T>> ListAsync(bool trackChanges = true, CancellationToken cancellationToken = default);
    Task<List<TType>> ListAsync<TType>(Expression<Func<T, TType>> selector, bool trackChanges = true, CancellationToken cancellationToken = default) where TType : class;
    Task<List<T>> ListByFilterAsync(Expression<Func<T, bool>> filter, bool trackChanges = true, CancellationToken cancellationToken = default);
    Task<List<TType>> ListByFilterAsync<TType>(Expression<Func<T, bool>> filter, Expression<Func<T, TType>> selector, bool trackChanges = true, CancellationToken cancellationToken = default) where TType : class;
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> GetQuery();
}
