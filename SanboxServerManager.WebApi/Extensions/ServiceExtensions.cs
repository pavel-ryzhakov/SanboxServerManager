using MassTransit;

namespace SanboxServerManager.WebApi.Extensions
{
    public static class ServiceExtensions
    { 
        public static void ConfigureMassTransit(this IServiceCollection services) => 
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                });
            });


    }
    }

