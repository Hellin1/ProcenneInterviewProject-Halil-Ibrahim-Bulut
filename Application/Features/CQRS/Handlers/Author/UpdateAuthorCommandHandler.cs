using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateAuthorCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorInDb = await _uow.GetRepository<Author>().GetByIdAsync(request.Id);
        authorInDb.Name = request.Name;

        await _uow.SaveChangesAsync();

        return Unit.Value;
    }
}
