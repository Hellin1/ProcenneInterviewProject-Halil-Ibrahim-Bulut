using Application.Dtos.Book;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers;

public class GetAuthorBooksQueryHandler : IRequestHandler<GetAuthorBooksQuery, List<BookListDto>>
{
    private readonly IUnitOfWork _uow;

    public GetAuthorBooksQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<BookListDto>> Handle(GetAuthorBooksQuery request, CancellationToken cancellationToken)
    {
        return await _uow.BookRepository.GetBooksOfAuthor(request.Id);
    }
}
