using MicroIMS.Application.Services;
using MicroIMS.Domain.Entities;

namespace MicroIMS.Infrastructure.Services;

internal sealed class EmailService : IEmailService
{
    public async Task SendUserCreatedEmailAsync(User user, CancellationToken cancellationToken = default)
    {
        // TODO: implement real email service
        await Task.CompletedTask;
    }
}
