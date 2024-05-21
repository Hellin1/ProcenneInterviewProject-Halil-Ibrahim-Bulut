using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public CreateAuthorCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        _uow.GetRepository<Author>().Create(new Author()
        {
            Name = request.Name,
            UserId = request.UserId,
        });

        await _uow.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
