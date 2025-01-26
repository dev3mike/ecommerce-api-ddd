using ECM.Domain.Aggregates;

namespace ECM.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
}