using MicroIMS.Application.Messaging;
using MicroIMS.Application.Repositories;
using MicroIMS.Domain.Common;
using MicroIMS.Domain.Entities;
using MicroIMS.Domain.Errors;
using MicroIMS.Domain.Repositories;
using MicroIMS.Domain.ValueObjects;

namespace MicroIMS.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUsersRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUsersRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(request.Email);

        if (emailResult.IsFailure)
        {
            return Result.Failure<Guid>(emailResult.Error);
        }

        if (!await _userRepository.IsEmailUniqueAsync(emailResult.Value, cancellationToken))
        {
            return Result.Failure<Guid>(DomainErrors.User.EmailAlreadyExists);
        }

        var user = User.Create(
            id: Guid.NewGuid(),
            email: emailResult.Value,
            firstName: request.FirstName,
            lastName: request.LastName
        );

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(user.Id);
    }
}
