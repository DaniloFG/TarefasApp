using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TarefasApp.Infra.Messages.Models;
using TarefasApp.Infra.Messages.Services;
using TarefasApp.Infra.Messages.Settings;

namespace TarefasApp.Infra.Messages.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;
        private readonly EmailService _emailService;

        public MessageConsumer(RabbitMQSettings rabbitMQSettings, EmailService emailService)
        {
            _rabbitMQSettings = rabbitMQSettings;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMQSettings.Url)
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.QueueDeclare(
                queue: _rabbitMQSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(model);

            consumer.Received += (sender, args) =>
            {
                var body = Encoding.UTF8.GetString(args.Body.ToArray());

                var message = JsonConvert.DeserializeObject<EmailMessageModel>(body);

                _emailService.SendMailAsync(message);

                model.BasicAck(args.DeliveryTag, false);
            };

            model.BasicConsume(_rabbitMQSettings.Queue, false, consumer);
        }
    }
}