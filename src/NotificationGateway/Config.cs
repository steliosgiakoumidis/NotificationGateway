using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationGateway
{
    public class Config
    {
        public EmailConfiguration EmailConfiguration { get; set; }

        public SmsConfiguration SmsConfiguration { get; set; }
    }

    public class EmailConfiguration
    {
        public string Hostname { get; set; }
        public string FromMailAddress { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int PortNumber { get; set; }
    }

    public class SmsConfiguration
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public string Handle { get; set; }
        public string From { get; set; }
    }
}
