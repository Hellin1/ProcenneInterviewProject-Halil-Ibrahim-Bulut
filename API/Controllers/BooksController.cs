using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ITransactionManager _transactionManager;

    public BooksController(ITransactionManager transactionManager)
    {
        _transactionManager = transactionManager;
    }

    [HttpGet]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendQuery(new ListBooksQuery(), cancellationToken);

        return Ok(resp.Result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendQuery(new GetBookByIdQuery(id), cancellationToken);

        return Ok(resp.Result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand cmd, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendCommand(cmd, cancellationToken);
        if (resp.IsSuccessful)
        {
            return Created();
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateBookCommand cmd, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendCommand(cmd, cancellationToken);
        if (resp.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendCommand(new DeleteAuthorCommand() { Id = id }, cancellationToken);
        if (resp.IsSuccessful)
        {
            return NoContent();
        }
        return BadRequest();
    }
}
