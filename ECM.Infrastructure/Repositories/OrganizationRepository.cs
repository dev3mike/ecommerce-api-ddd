using ECM.Domain.Entities;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECM.Infrastructure.Repositories;

public class OrganizationRepository(ApplicationAppDbContext context, IDomainEventDispatcher eventDispatcher)
    : IOrganizationRepository
{
    private readonly ApplicationAppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IDomainEventDispatcher _domainEventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));

    public async Task AddAsync(Organization organization)
    {
        await _context.Organizations.AddAsync(organization);
        await _context.SaveChangesAsync();
        await _domainEventDispatcher.DispatchAsync(organization);
    }

    public async Task<Organization?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations.FirstOrDefaultAsync(x => x.Id == id);
    }
} 