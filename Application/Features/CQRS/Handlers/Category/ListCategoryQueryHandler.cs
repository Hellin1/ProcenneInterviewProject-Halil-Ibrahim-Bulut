using Application.Dtos.Category;
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

public class ListCategoryQueryHandler : IRequestHandler<ListCategoryQuery, List<CategoryListDto>>
{
    private readonly IUnitOfWork _uow;

    public ListCategoryQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<CategoryListDto>> Handle(ListCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _uow.GetRepository<Category>().ListAsync(c => new CategoryListDto
        {
            Id = c.Id,
            Name = c.Name,  
        });
    }
}
