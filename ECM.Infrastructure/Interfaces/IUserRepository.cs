using ECM.Domain.Entities;

namespace ECM.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id, bool includeOrganizations = false);
}