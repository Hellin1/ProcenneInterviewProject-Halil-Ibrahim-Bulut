using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteBookCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _uow.GetRepository<Book>().GetByIdAsync(request.Id);
        _uow.GetRepository<Book>().Delete(book);

        await _uow.SaveChangesAsync();
    }
}
