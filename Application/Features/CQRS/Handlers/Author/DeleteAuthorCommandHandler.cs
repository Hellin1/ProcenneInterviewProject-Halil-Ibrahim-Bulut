using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteAuthorCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _uow.GetRepository<Author>().GetByIdAsync(request.Id);

        _uow.GetRepository<Author>().Delete(author);

        await _uow.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
