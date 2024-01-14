using MicroIMS.Domain.Entities;
using MicroIMS.Domain.ValueObjects;

namespace MicroIMS.Domain.Repositories;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken = default);
    void Add(User user);
}