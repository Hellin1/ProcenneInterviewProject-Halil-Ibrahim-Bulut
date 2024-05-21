using Application.Dtos.Category;
using MediatR;

namespace Application.Features.CQRS.Commands;

public class UpdateBookCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<int> CategoryIds { get; set; } = [];
    public List<int> AuthorIds { get; set; }
}
