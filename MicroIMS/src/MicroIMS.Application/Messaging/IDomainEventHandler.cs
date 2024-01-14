using MediatR;
using MicroIMS.Domain.Primitives;

namespace MicroIMS.Application.Messaging;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}