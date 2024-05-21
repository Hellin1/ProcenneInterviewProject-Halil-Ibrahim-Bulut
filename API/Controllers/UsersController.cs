using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Application.Tools;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ITransactionManager _transactionManager;

    public UsersController(ITransactionManager transactionManager)
    {
        _transactionManager = transactionManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserCommand cmd)
    {
        var resp = await _transactionManager.SendQuery(cmd);
        if (resp.Result)
        {
            var token = JwtTokenGenerator.GenerateToken(new Application.Dto.UserDto
            {

            });
            return Created("", token);
        }

        return Unauthorized("Invalid username or password");
    }

    [HttpPost]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }

}
