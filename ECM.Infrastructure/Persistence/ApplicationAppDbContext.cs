using ECM.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace ECM.Infrastructure.Persistence;

public class ApplicationAppDbContext(DbContextOptions<ApplicationAppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationAppDbContext).Assembly);
    }
} 