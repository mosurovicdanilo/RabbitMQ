using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omega.Interfaces;
using Omega.Models;

namespace Omega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRabbitMqSender _sender;

        public RequestController(IRabbitMqSender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public IActionResult Publish(Request request)
        {
            _sender.Send(request);

            return NoContent();
        }
    }
}
