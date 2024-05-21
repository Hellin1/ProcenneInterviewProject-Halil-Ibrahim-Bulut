using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ITransactionManager _transactionManager;

    public CategoriesController(ITransactionManager transactionManager)
    {
        _transactionManager = transactionManager;
    }

    [HttpGet]
    public async Task<IActionResult> List(CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendQuery(new ListCategoryQuery(), cancellationToken);

        return Ok(resp.Result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendQuery(new GetCategoryByIdQuery(id), cancellationToken);

        return Ok(resp.Result);
    }

    [HttpGet("{id}/book")]
    public async Task<IActionResult> GetCategoryBooks(int id)
    {
        return Ok();
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand cmd, CancellationToken cancellationToken)
    {
        var resp = await _transactionManager.SendCommand(cmd, cancellationToken);
        if (resp.IsSuccessful)
        {
            return Created();
        }
        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateCategoryCommand cmd, CancellationToken cancellationToken)
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
