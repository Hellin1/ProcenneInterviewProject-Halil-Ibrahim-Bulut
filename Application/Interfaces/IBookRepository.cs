using Application.Dtos.Book;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface IBookRepository
{
    Task<Book> GetBookWithNavProps(CancellationToken cancellationToken = default);
    Task<List<Book>> ListBooksWithNavProps(CancellationToken cancellationToken = default);

    Task<List<BookListDto>> GetBooksOfAuthor(int authorId, CancellationToken cancellationToken = default);
}
