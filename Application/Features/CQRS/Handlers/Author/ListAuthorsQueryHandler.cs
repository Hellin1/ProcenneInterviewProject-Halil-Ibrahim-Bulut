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

public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, List<AuthorListDto>>
{
    private readonly IUnitOfWork _uow;

    public ListAuthorsQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<AuthorListDto>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
    {
        return await _uow.GetRepository<Author>().ListAsync(a => new AuthorListDto
        {
            Id = a.Id,
            Name = a.Name
        });

    }
}
