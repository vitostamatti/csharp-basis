using MicroIMS.Domain.Entities;
using MicroIMS.Domain.Repositories;
using MicroIMS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace MicroIMS.Infrastructure.Repositories;

public sealed class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Set<User>().Add(user);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email, CancellationToken cancellationToken)
    {
        return !await _dbContext.Set<User>().AnyAsync(x => x.Email == email, cancellationToken);
    }
}