using System.Windows.Input;
using MicroIMS.Application.Messaging;

namespace MicroIMS.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Email,
    string FirstName,
    string LastName
) : ICommand<Guid>;

