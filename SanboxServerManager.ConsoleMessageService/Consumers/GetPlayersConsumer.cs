using MassTransit;
using Newtonsoft.Json;
using SanboxServerManager.SharedModels;

namespace SanboxServerManager.ConsoleMessageService.Consumers
{
    class GetPlayersConsumer : IConsumer<PlayersReceived>
    {
        public async Task Consume(ConsumeContext<PlayersReceived> context)
        {
            var message = context.Message;
            Console.WriteLine($"{message.Message}");
        }
    }
}
