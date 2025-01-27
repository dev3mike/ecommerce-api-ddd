using ECM.Domain.Entities;

namespace ECM.Infrastructure.Interfaces;

public interface IOrganizationRepository
{
    Task AddAsync(Organization organization);
    Task<Organization?> GetByIdAsync(Guid id);
} 