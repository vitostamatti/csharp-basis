namespace MicroIMS.Domain.Events;

public sealed record UserCreatedEvent(
    Guid Id,
    Guid UserId
) : DomainEvent(Id);