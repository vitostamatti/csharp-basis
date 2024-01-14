using MediatR;
using MicroIMS.Application.Messaging;
using MicroIMS.Contracts.Users;
using MicroIMS.Domain.Common;
using MicroIMS.Domain.Errors;
using MicroIMS.Domain.Repositories;

namespace MicroIMS.Application.Users.Queries.GetUserById;



public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdResult>
{
    private readonly IUsersRepository _userRepository;

    public GetUserByIdQueryHandler(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<GetUserByIdResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            return Result.Failure<GetUserByIdResult>(DomainErrors.User.UserIdNotFound(request.Id));
        }

        var result = new GetUserByIdResult(
            user.Id,
            user.Email.Value,
            user.FirstName,
            user.LastName
        );

        return Result.Success(result);

    }

}
