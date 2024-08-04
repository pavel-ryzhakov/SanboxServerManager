using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SanboxServerManager.Core.Interfaces;
using SanboxServerManager.Infrastructure.Repositories;

namespace SanboxServerManager.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SandboxContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SandboxServerContext")));
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            return services;
        }
    }
}
