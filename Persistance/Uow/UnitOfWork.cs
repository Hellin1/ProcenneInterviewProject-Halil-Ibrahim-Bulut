using Application.Interfaces;
using Persistance.Context;
using Persistance.Repositories;

namespace Persistance.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryContext _context;
    // specific repositories

    public IBookRepository BookRepository { get; }

    public UnitOfWork(LibraryContext context, IBookRepository bookRepository)
    {
        _context = context;
        BookRepository = bookRepository;
    }

    public IRepository<T> GetRepository<T>() where T : class, new()
    {
        return new Repository<T>(_context);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
