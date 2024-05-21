using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands;

public class CreateAuthorCommand : IRequest<Unit>
{
    public string Name { get; set; }
    // will get from controller
    public int? UserId { get; set; }
}
