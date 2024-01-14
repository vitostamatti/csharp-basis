namespace MicroIMS.Contracts.Users;

public sealed record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName
);