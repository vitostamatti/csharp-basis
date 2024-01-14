using System;
using System.Collections.Generic;

// IRequest interface
public interface IRequest<TResponse>
{
}
// IRequestHandler interface
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    TResponse Handle(TRequest request);
}

// Mediator interface
public interface IMediator
{
    TResponse Send<TResponse>(IRequest<TResponse> request);
}

// Concrete Mediator
public class Mediator : IMediator
{
    private readonly Dictionary<Type, object> handlers = new Dictionary<Type, object>();

    public void RegisterHandler<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
        where TRequest : IRequest<TResponse>
    {
        handlers[typeof(TRequest)] = handler;
    }

    public TResponse Send<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        var handler = handlers[handlerType];

        return (TResponse)handlerType
            .GetMethod("Handle")!
            .Invoke(handler, new object[] { request })!;
    }
}

// Concrete Request
public class GreetRequest : IRequest<string>
{
    public string Name { get; set; } = string.Empty;
}

// Concrete RequestHandler
public class GreetRequestHandler : IRequestHandler<GreetRequest, string>
{
    public string Handle(GreetRequest request)
    {
        return $"Hello, {request.Name}!";
    }
}
