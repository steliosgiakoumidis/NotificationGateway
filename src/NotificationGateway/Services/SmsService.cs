using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationGateway.Services
{
    public class SmsService : ISmsService
    {
        private SmsConfiguration _config;
        private IHttpClientFactory _clientFactory;

        public SmsService(IOptions<Config> config, IHttpClientFactory clientFactory)
        {
            _config = config.Value.SmsConfiguration;
            _clientFactory = clientFactory;
        }

        public async Task SendSmsAsync(string receiver, string body)
        {
            try
            {
                var encodedBody = System.Web.HttpUtility.UrlPathEncode(body);
                var uri = 
                    $"https://api.budgetsms.net/sendsms/?username={_config.Username}&handle={_config.Handle}&userid={_config.UserId}&msg={encodedBody}&from={_config.From}&to={receiver}";
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync(uri);
                Log.Information($"Message: {body}. Is sent to {receiver}" );
            }
            catch (Exception ex)
            {
                Log.Error($"The following Http error occured when contacting external sms service. Error: {ex}");
                throw;
            }
        }
    }
}
