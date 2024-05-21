using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Unit>
{
    private readonly IUnitOfWork _uow;

    public CreateBookCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var newBook = new Book
        {
            Title = request.Title,
        };

        foreach (var categoryId in request.CategoryIds)
        {
            newBook.BookCategories.Add(new BookCategory
            {
                Book = newBook,
                CategoryId = categoryId
            });
        }

        foreach (var authorId in request.AuthorIds)
        {
            newBook.BookAuthors.Add(new BookAuthor
            {
                AuthorId = authorId,
                Book = newBook,
            });
        }


        _uow.GetRepository<Book>().Create(newBook);

        await _uow.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
