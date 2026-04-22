using Azure.Messaging.ServiceBus;

namespace ListingService.Services
{
    public class QueueSenderService
    {
        private readonly string _connectionString;
        private const string QueueName = "hlebhramiaka";

        public QueueSenderService(IConfiguration configuration)
        {
            _connectionString = configuration["ServiceBus:SendConnectionString"]!;
        }

        public async Task SendMessageAsync(string text)
        {
            await using var client = new ServiceBusClient(_connectionString);
            var sender = client.CreateSender(QueueName);

            var message = new ServiceBusMessage(text);

            await sender.SendMessageAsync(message);
        }
    }
}