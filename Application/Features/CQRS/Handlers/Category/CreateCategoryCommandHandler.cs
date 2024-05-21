using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public CreateCategoryCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        _uow.GetRepository<Category>().Create(new Category
        {
            Name = request.Name,
        });

        await _uow.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
