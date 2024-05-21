using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;

public interface ITransactionManager
{
    Task<ResultModel<TResult>> SendCommand<TResult>(IRequest<TResult> cmd, CancellationToken cancellationToken = default);
    Task<ResultModel<TResult>> SendQuery<TResult>(IRequest<TResult> query, CancellationToken cancellationToken = default);
}
