using MediatR;
using MicroIMS.Domain.Common;

namespace MicroIMS.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}