using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega.Interfaces
{
    public interface IRabbitMqConnectionFactory
    {
        public IConnection CreateConnection();
    }
}
