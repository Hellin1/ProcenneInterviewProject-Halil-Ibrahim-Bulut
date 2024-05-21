using Application.Dtos.Book;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> ListBooksWithNavProps(CancellationToken cancellationToken = default)
    {
        var books = await _context.Books
                        .Include(b => b.BookCategories)
                        .Include(b => b.BookAuthors)
                        .ToListAsync(cancellationToken);

        return books;
    }

    public async Task<Book> GetBookWithNavProps(CancellationToken cancellationToken = default)
    {
        var book = await _context.Books
                        .Include(b => b.BookCategories)
                        .Include(b => b.BookAuthors)
                        .FirstOrDefaultAsync(cancellationToken);

        return book;
    }

    public async Task<List<BookListDto>> GetBooksOfAuthor(int authorId, CancellationToken cancellationToken = default)
    {
        var books = await _context.BookAuthors
                        .Where(ab => ab.AuthorId == authorId)
                        .Select(ab => new BookListDto
                        {
                            Id = ab.BookId,
                            Title = ab.Book.Title
                        })
                        .ToListAsync();

        return books;


    }
}
