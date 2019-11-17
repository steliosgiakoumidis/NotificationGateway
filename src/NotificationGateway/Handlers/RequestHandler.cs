using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationCommon.Models;
using NotificationGateway.Services;
using Serilog;

namespace NotificationGateway.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private IEmailService _emailService;
        private ISmsService _smsService;
        public RequestHandler(IEmailService emailService, ISmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }
        public async Task HandleSendRequest(GatewaySendout sendout, 
            Config conf)
        {
            switch (sendout.MeansOfCommunication)
            {
                case Enums.MeansOfCommunication.Email:
                    await _emailService.SendEmailAsync(sendout.ContactDetails, sendout.Text);
                    Log.Information($"Email sent to {sendout.ContactDetails} with text {sendout.Text}");
                    break;
                case Enums.MeansOfCommunication.SMS:
                    await _smsService.SendSmsAsync(sendout.ContactDetails, sendout.Text);
                    Log.Information($"Email sent to {sendout.ContactDetails} with text {sendout.Text}");
                    break;
            }
        }
    }
}
