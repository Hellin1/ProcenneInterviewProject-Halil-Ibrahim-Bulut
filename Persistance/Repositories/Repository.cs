using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly LibraryContext _context;

        public Repository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<T?> GetByIdAsync(int id, bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return trackChanges ? await _context.Set<T>().FindAsync(id) : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken);
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter, bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return trackChanges ? await _context.Set<T>().Where(filter).FirstOrDefaultAsync() : await _context.Set<T>().Where(filter).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
        public async Task<TType?> GetByFilterAsync<TType>(Expression<Func<T, bool>> filter, Expression<Func<T, TType>> selector, bool trackChanges = true, CancellationToken cancellationToken = default) where TType : class
        {
            return trackChanges ? await _context.Set<T>().Where(filter).Select(selector).FirstOrDefaultAsync() : await _context.Set<T>().Where(filter).AsNoTracking().Select(selector).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> ListAsync(bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return trackChanges ? await _context.Set<T>().ToListAsync() : await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<List<TType>> ListAsync<TType>(Expression<Func<T, TType>> selector, bool trackChanges, CancellationToken cancellationToken = default) where TType : class
        {
            return trackChanges ? await _context.Set<T>().Select(selector).ToListAsync() : await _context.Set<T>().AsNoTracking().Select(selector).ToListAsync(cancellationToken);
        }

        public async Task<List<T>> ListByFilterAsync(Expression<Func<T, bool>> filter, bool trackChanges = true, CancellationToken cancellationToken = default)
        {
            return trackChanges ? await _context.Set<T>().Where(filter).ToListAsync() : await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<List<TType>> ListByFilterAsync<TType>(Expression<Func<T, bool>> filter, Expression<Func<T, TType>> selector, bool trackChanges = true, CancellationToken cancellationToken = default) where TType : class
        {
            return trackChanges ? await _context.Set<T>().AsNoTracking().Where(filter).Select(selector).ToListAsync(cancellationToken) : await _context.Set<T>().AsNoTracking().Where(filter).Select(selector).ToListAsync(cancellationToken);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
