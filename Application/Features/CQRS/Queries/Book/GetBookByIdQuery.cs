using Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries;

public class GetBookByIdQuery : IRequest<BookListDto>
{
    public int Id { get; set; }

    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
}
