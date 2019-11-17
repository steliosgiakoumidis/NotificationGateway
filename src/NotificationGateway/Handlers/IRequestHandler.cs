using NotificationCommon.Models;
using NotificationGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationGateway.Handlers
{
    public interface IRequestHandler
    {
        Task HandleSendRequest(GatewaySendout sendout, Config conf);
    }
}
