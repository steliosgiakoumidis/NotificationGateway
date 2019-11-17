﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationGateway.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receiver, string body);
    }
}
