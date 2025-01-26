using ECM.Domain.Entities;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.Where(x=>x.Id.Equals(id)).SingleOrDefaultAsync();
    }
}