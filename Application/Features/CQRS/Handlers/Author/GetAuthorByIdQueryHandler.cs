using Application.Dtos.Author;
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

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorListDto>
{
    private readonly IUnitOfWork _uow;

    public GetAuthorByIdQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<AuthorListDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _uow.GetRepository<Author>().GetByIdAsync(request.Id);
        return new AuthorListDto
        {
            Id = author.Id,
            Name = author.Name
        };

    }
}
