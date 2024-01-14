using MicroIMS.Domain.Entities;

namespace MicroIMS.Application.Services;

public interface IEmailService
{
    Task SendUserCreatedEmailAsync(User user, CancellationToken cancellationToken = default);
}