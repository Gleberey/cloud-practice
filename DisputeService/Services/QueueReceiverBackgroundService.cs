using Azure.Messaging.ServiceBus;

namespace DisputeService.Services
{
    public class QueueReceiverBackgroundService : BackgroundService
    {
        private readonly string _connectionString;
        private const string QueueName = "hlebhramiaka";

        public QueueReceiverBackgroundService(IConfiguration configuration)
        {
            _connectionString = configuration["ServiceBus:ListenConnectionString"]!;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using var client = new ServiceBusClient(_connectionString);
            var receiver = client.CreateReceiver(QueueName);

            while (!stoppingToken.IsCancellationRequested)
            {
                var message = await receiver.ReceiveMessageAsync(
                    TimeSpan.FromSeconds(2),
                    stoppingToken);

                if (message != null)
                {
                    var body = message.Body.ToString();
                    Console.WriteLine($"Received message: {body}");
                    await receiver.CompleteMessageAsync(message, stoppingToken);
                }
                else
                {
                    Console.WriteLine("No messages in queue");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}