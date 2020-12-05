using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega.Interfaces
{
    public interface IRabbitMqSettings
    {
        string HostName { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string QueueName { get; set; }
        int Port { get; set; }

    }
}
