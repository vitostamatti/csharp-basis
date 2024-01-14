using MicroIMS.Application.Messaging;
using MicroIMS.Contracts.Users;

namespace MicroIMS.Application.Users.Queries.GetUserById;


public sealed record GetUserByIdQuery(
    Guid Id
) : IQuery<GetUserByIdResult>;