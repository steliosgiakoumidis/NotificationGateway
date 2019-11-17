using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NotificationGateway.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        private EmailConfiguration _conf;
        public EmailService(IOptions<Config> conf)
        {
            _conf = conf.Value.EmailConfiguration;
            _smtpClient = new SmtpClient(_conf.Hostname, _conf.PortNumber);
            _smtpClient.Credentials = new NetworkCredential(_conf.Username, _conf.Password);
            _smtpClient.EnableSsl = false;
        }

        public async Task SendEmailAsync(string receiver, string body)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.Body = body;
                mailMessage.To.Add(receiver);
                mailMessage.From = new MailAddress(_conf.FromMailAddress);
                _smtpClient.SendCompleted += (o, e) =>
                {
                    _smtpClient.Dispose();
                    mailMessage.Dispose();
                };
                await _smtpClient.SendMailAsync(mailMessage);
                Log.Information($"Email with text: {body} was sent to {receiver}");
            }catch(Exception ex)
            {
                Log.Error($"Exception thrown when send email to {receiver}. Exception info: {ex}");
            }
            
        }
    }
}
