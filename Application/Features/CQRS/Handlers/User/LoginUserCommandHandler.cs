using Application.Features.CQRS.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.User;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
{
    private readonly IIdentityService _identityService;

    public LoginUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.SignInAsync(request.UserName, request.Password);
        return result;
    }
}
