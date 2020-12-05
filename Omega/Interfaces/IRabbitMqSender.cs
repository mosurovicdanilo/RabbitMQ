using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omega.Interfaces
{
    public interface IRabbitMqSender
    {
        public void Send(object message);
    }
}
