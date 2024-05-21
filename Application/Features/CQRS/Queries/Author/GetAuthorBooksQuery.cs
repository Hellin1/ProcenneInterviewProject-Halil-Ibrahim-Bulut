using Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries;

public class GetAuthorBooksQuery : IRequest<List<BookListDto>>
{
    public int Id { get; set; }

    public GetAuthorBooksQuery(int id)
    {
        Id = id;
    }
}
