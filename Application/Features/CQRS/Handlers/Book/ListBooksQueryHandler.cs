using Application.Dtos.Book;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers;

public class ListBooksQueryHandler : IRequestHandler<ListBooksQuery, List<BookListDto>>
{
    private readonly IUnitOfWork _uow;

    public ListBooksQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<BookListDto>> Handle(ListBooksQuery request, CancellationToken cancellationToken)
    {
        return await _uow.GetRepository<Book>().ListAsync(b => new BookListDto
        {
            Id = b.Id,
            Title = b.Title,
        });

    }
}
