using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using TarefasApp.Infra.Messages.Settings;

namespace TarefasApp.Infra.Messages.Producers
{
    public class MessageProducer
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        public MessageProducer(RabbitMQSettings rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMQSettings.Url)
            };

            using var connection = factory.CreateConnection();
            using var model = connection.CreateModel();

            model.QueueDeclare(
                queue: _rabbitMQSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var jsonMessage = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            model.BasicPublish(
                exchange: string.Empty,
                routingKey: _rabbitMQSettings.Queue,
                basicProperties: null,
                body: body
            );
        }
    }
}