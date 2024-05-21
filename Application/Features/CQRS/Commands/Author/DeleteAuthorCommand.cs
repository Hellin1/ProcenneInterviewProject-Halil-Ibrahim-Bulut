using MediatR;

namespace Application.Features.CQRS.Commands;

public class DeleteAuthorCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
