using ECM.Infrastructure.Interfaces;
using ECM.Infrastructure.Persistence;
using ECM.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECM.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        
        services.AddDbContext<ApplicationAppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationAppDbContext).Assembly.FullName)));
    }
} 