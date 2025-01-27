using ECM.Domain.Entities;
using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECM.Infrastructure.Services;

public class UserOrganizationService(
    ApplicationAppDbContext context,
    IUserRepository userRepository,
    IOrganizationRepository organizationRepository)
{
    public async Task<(User User, Organization Organization)> CreateUserWithOrganizationAsync(
        string name,
        string email,
        string password)
    {
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Create user
            var user = new User(name, email, password);
            await userRepository.AddAsync(user);

            // Create default organization
            var organization = new Organization("Default", user);
            await organizationRepository.AddAsync(organization);

            // Commit transaction
            await transaction.CommitAsync();

            return (user, organization);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
} 