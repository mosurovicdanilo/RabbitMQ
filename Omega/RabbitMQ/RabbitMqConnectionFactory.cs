using Omega.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega.RabbitMQ
{
    public class RabbitMqConnectionFactory : IRabbitMqConnectionFactory
    {
        private readonly IRabbitMqSettings _rabbitMqSettings;

        public RabbitMqConnectionFactory(IRabbitMqSettings rabbitMqSettings)
        {
            _rabbitMqSettings = rabbitMqSettings;
        }
        public IConnection CreateConnection()
        {
            return new ConnectionFactory
            {
                HostName = _rabbitMqSettings.HostName,
                UserName = _rabbitMqSettings.UserName,
                Password = _rabbitMqSettings.Password,
                Port = _rabbitMqSettings.Port,
                RequestedConnectionTimeout = new TimeSpan(0, 0, 0, 0, milliseconds: 3000)
            }.CreateConnection();
        }
    }
}
