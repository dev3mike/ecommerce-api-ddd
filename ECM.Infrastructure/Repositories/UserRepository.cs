using ECM.Domain.Aggregates;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;

namespace ECM.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationAppDbContext _context;
    public UserRepository(ApplicationAppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}