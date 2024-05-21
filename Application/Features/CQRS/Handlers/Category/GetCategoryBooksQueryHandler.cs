using Application.Dtos.Book;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers
{
    public class GetCategoryBooksQueryHandler : IRequestHandler<GetCategoryBooksQuery, List<BookListDto>>
    {
        private readonly IUnitOfWork _uow;

        public Task<List<BookListDto>> Handle(GetCategoryBooksQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
