using MicroIMS.Domain.Primitives;

namespace MicroIMS.Domain.Events;

public abstract record DomainEvent(Guid Id) : IDomainEvent;