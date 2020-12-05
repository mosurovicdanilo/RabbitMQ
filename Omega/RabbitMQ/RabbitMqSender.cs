using Omega.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Omega.RabbitMQ
{
    public class RabbitMqSender : IRabbitMqSender
    {
        private readonly IRabbitMqConnectionFactory _connectionFactory;
        private readonly IRabbitMqSettings _settings;

        public RabbitMqSender(IRabbitMqConnectionFactory connectionFactory, IRabbitMqSettings settings)
        {
            _connectionFactory = connectionFactory;
            _settings = settings;
        }
        public void Send(object message)
        {
            var connection = _connectionFactory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _settings.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: string.Empty, mandatory: false, basicProperties: null, routingKey: _settings.QueueName, body: body);
        }
    }
}
