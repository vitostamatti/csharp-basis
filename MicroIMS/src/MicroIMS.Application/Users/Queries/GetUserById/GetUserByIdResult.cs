public sealed record GetUserByIdResult(
    Guid Id,
    string Email,
    string FirstName,
    string LastName
);