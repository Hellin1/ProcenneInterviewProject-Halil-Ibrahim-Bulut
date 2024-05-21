using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IUnitOfWork
{
    // specific repositories
    IBookRepository BookRepository { get; }
    IRepository<T> GetRepository<T>() where T : class, new();
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
