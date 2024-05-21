using Application.Dtos.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Queries;

public class GetAuthorByIdQuery : IRequest<AuthorListDto>
{
    public int Id { get; set; }

    public GetAuthorByIdQuery(int id)
    {
        Id = id;
    }
}
