using MediatR;
using MicroIMS.Domain.Common;

namespace MicroIMS.Application.Messaging;

public interface ICommand : IRequest<Result>
{
}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}