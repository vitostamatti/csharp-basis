using MediatR;
using MicroIMS.Domain.Common;

namespace MicroIMS.Application.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}