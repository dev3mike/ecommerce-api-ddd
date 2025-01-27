using ECM.Domain.Entities;
using ECM.Domain.Exceptions;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECM.Infrastructure.Repositories;

public class UserRepository(ApplicationAppDbContext context, IDomainEventDispatcher eventDispatcher)
    : IUserRepository
{
    private readonly ApplicationAppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IDomainEventDispatcher _domainEventDispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));

    public async Task AddAsync(User user)
    {
        try{
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        
            await _domainEventDispatcher.DispatchAsync(user);
        }
        catch (DbUpdateException ex) when (IsDuplicateEmailException(ex))
        {
            throw new DuplicateEmailException(user.Email, ex);
        }
    }
    
    private static bool IsDuplicateEmailException(DbUpdateException ex)
    {
        // Check if the inner exception is a PostgresException and the error code indicates a unique constraint violation
        if (ex.InnerException is Npgsql.PostgresException postgresException)
        {
            return postgresException.SqlState == "23505"; // 23505: Unique constraint violation
        }

        return false;
    }

    public async Task<User?> GetByIdAsync(Guid id, bool includeOrganizations = false)
    {
        var query = _context.Users.AsQueryable();

        if (includeOrganizations)
        {
            query = query.Include(x => x.Organizations);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}