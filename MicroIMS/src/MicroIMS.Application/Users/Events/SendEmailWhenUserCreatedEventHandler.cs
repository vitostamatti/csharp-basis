using MicroIMS.Application.Messaging;
using MicroIMS.Application.Services;
using MicroIMS.Domain.Events;
using MicroIMS.Domain.Repositories;

namespace MicroIMS.Application.Users.Events;


public sealed class SendEmailWhenUserCreatedEventHandler : IDomainEventHandler<UserCreatedEvent>
{
    private readonly IUsersRepository _userRepository;
    private readonly IEmailService _emailService;

    public SendEmailWhenUserCreatedEventHandler(IEmailService emailService, IUsersRepository userRepository)
    {
        _emailService = emailService;
        _userRepository = userRepository;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(
            id: notification.Id,
            cancellationToken: cancellationToken
        );

        if (user is null)
        {
            // Ideally Log somewhere
            return;
        }

        await _emailService.SendUserCreatedEmailAsync(user, cancellationToken);
    }
}
