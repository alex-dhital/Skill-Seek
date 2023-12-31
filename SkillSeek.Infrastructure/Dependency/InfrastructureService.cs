using SkillSeek.Application.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillSeek.Infrastructure.Implementation.Repository.Base;
using SkillSeek.Infrastructure.Persistence;
using SkillSeek.Infrastructure.Persistence.Seed;

namespace SkillSeek.Infrastructure.Dependency;

public static class InfrastructureService
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("SkillSeek.Infrastructure")));

        services.AddScoped<IDbInitializer, DbInitializer>();

        services.AddTransient<IGenericRepository, GenericRepository>();

        return services;
    }
    
}