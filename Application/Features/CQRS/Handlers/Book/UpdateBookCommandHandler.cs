using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateBookCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _uow.BookRepository.GetBookWithNavProps(cancellationToken);

        book.BookCategories.Clear();
        foreach (var categoryId in request.CategoryIds)
        {
            book.BookCategories.Add(new BookCategory
            {
                Book = book,
                CategoryId = categoryId
            });
        }

        book.BookAuthors.Clear();
        foreach (var authorId in request.AuthorIds)
        {
            book.BookAuthors.Add(new BookAuthor
            {
                AuthorId = authorId,
                Book = book,
            });
        }

        await _uow.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
