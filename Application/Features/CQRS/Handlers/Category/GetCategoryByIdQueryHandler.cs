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

namespace Application.Features.CQRS.Handlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryListDto>
    {
        private readonly IUnitOfWork _uow;

        public GetCategoryByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CategoryListDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _uow.GetRepository<Category>().GetByIdAsync(request.Id);
            return new CategoryListDto
            {
                Id = category.Id,
                Name = category.Name,  
            };
        }
    }
}
