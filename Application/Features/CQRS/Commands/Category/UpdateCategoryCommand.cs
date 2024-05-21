using MediatR;

namespace Application.Features.CQRS.Commands;

public class UpdateCategoryCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
