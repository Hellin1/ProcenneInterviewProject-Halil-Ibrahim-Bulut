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

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookListDto>
{
    private readonly IUnitOfWork _uow;

    public GetBookByIdQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<BookListDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _uow.GetRepository<Book>().GetByIdAsync(request.Id);

        return new BookListDto
        {
            Id = book.Id,
            Title = book.Title,
        };
    }
}
