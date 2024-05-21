using Application.Helpers;
using Application.Interfaces;
using Application.Responses;
using FluentValidation;
using MediatR;
using Persistance.Context;

namespace Application;

public class TransactionManager : ITransactionManager
{
    private readonly LibraryContext _context;
    private readonly IMediator _mediator;

    public TransactionManager(LibraryContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<ResultModel<TResult>> SendCommand<TResult>(IRequest<TResult> cmd, CancellationToken cancellationToken)
    {
        var output = new ResultModel<TResult>();
        using var trn = await _context.Database.BeginTransactionAsync();
        try
        {
            var result = await _mediator.Send(cmd, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            await trn.CommitAsync();
            output.IsSuccessful = true;
            output.Result = result;
        }
        catch (ValidationException ex)
        {
            output.IsSuccessful = false;
            if (ex.Errors.Any())
            {
                output.Errors = ex.Errors.ToErrorModel();
            }
            else
            {
                output.Errors.Add(new ErrorModel
                {
                    ErrorCode = "1001",
                    ErrorMessage = ex.Message.ToString(),
                });
            }
            await trn.RollbackAsync();
        }
        catch (Exception ex)
        {
            output.IsSuccessful = false;
            output.Errors = new List<ErrorModel>() { (new ErrorModel() { ErrorCode = "1001", ErrorMessage = ex.Message.ToString() }) };
            await trn.RollbackAsync();
        }


        return output;
    }

    public async Task<ResultModel<TResult>> SendQuery<TResult>(IRequest<TResult> query, CancellationToken token)
    {
        var output = new ResultModel<TResult>();
        try
        {
            var result = await _mediator.Send(query, token);

            output.IsSuccessful = true;
            output.Result = result;
        }
        catch (ValidationException ex)
        {
            output.IsSuccessful = false;
            if (ex.Errors.Any())
            {
                output.Errors = ex.Errors.ToErrorModel();
            }
            else
            {
                output.Errors.Add(new ErrorModel
                {
                    ErrorCode = "1001",
                    ErrorMessage = ex.Message.ToString(),
                });
            }
        }
        catch (Exception ex)
        {
            output.IsSuccessful = false;
            output.Errors = new List<ErrorModel>() { new ErrorModel() { ErrorCode = "1001", ErrorMessage = ex.Message.ToString() } };
        }
        return output;
    }
}
