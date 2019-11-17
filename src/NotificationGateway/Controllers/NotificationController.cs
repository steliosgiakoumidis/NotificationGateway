using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NotificationCommon.Models;
using NotificationGateway.Handlers;
using NotificationGateway.Services;

namespace NotificationGateway.Controllers
{
    [Route("api/[Controller]")]
    public class NotificationController : Controller
    {
        private Config _config;
        private IRequestHandler _handler;

        public NotificationController(IOptions<Config> config, IRequestHandler requestHandler)
        {
            _config = config.Value;
            _handler = requestHandler;
        }

        [HttpPost]
        public async Task SendNotification([FromBody] GatewaySendout sendout)
        {
            await _handler.HandleSendRequest(sendout, _config);
        }

        
    }
}