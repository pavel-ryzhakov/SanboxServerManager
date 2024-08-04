using Microsoft.Extensions.DependencyInjection;
using SanboxServerManager.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SanboxServerManager.Application.Services;

namespace SanboxServerManager.Application
{
    public static class ApplicationContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            return services;
        }
    }
}
