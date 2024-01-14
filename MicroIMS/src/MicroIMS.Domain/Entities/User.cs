using MicroIMS.Domain.Primitives;
using MicroIMS.Domain.ValueObjects;
namespace MicroIMS.Domain.Entities;

public sealed class User : AggregateRoot
{
    public Email Email { get; } = null!;
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    private User()
    {
    }
    private User(
        Guid id,
        Email email,
        string firstName,
        string lastName
    ) : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
    public static User Create(
        Guid id,
        Email email,
        string firstName,
        string lastName
    )
    {
        var user = new User(
            id,
            email,
            firstName,
            lastName
        );
        // Possibly raise domain event
        return user;
    }
}