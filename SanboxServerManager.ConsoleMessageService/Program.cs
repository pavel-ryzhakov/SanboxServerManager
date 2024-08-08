using MassTransit;
using SanboxServerManager.ConsoleMessageService.Consumers;
using SanboxServerManager.SharedModels;

namespace SanboxServerManager.ConsoleMessageService
{
    internal class Program
    {
        static async Task Main(string[] args)
        { 
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                

                cfg.ReceiveEndpoint("player-event", e =>
                    {
                        e.Consumer<GetPlayersConsumer>();
                });


            });

            await busControl.StartAsync(new CancellationToken());

            try
            {
                Console.WriteLine("Press enter to exit");
                await Task.Run(() => Console.ReadLine());
            }
            finally
            {
                await busControl.StopAsync();
            }

        }
    }
}
