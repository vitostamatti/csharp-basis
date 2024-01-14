using MicroIMS.Domain.Common;

namespace MicroIMS.Domain.Errors;

public static class DomainErrors
{
    public static class Email
    {
        public static readonly Error Invalid = new(
            "Email.InvalidEmail",
            "Email format is invalid"
        );
        public static readonly Error Empty = new(
            "Email.EmptyEmail",
            "Email is empty"
        );
    }

    public static class User
    {
        public static readonly Error EmailAlreadyExists = new(
            "User.EmailAlreadyExists",
            "Email already in use"
        );
        public static readonly Func<Guid, Error> UserIdNotFound = (Guid id) => new(
            "User.NotFound",
            $"User with id {id} was not found"
        );
    }
}