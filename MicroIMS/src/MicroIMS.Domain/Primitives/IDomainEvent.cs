using MediatR;

namespace MicroIMS.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}