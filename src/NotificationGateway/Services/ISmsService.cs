using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationGateway.Services
{
    public interface ISmsService
    {
        Task SendSmsAsync(string receiver, string body);
    }
}
