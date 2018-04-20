using Microsoft.Extensions.Configuration;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Services.Data
{
    public class TwitterKeys : ITwitterKeys
    {
        private readonly IConfiguration configuration;

        public TwitterKeys(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConsumerKey => configuration.GetSection("TwitterKeys")["ConsumerKey"];
        public string ConsumerSecret => configuration.GetSection("TwitterKeys")["ConsumerSecret"];
        public string AccessToken => configuration.GetSection("TwitterKeys")["AccessToken"];
        public string AccessSecret => configuration.GetSection("TwitterKeys")["AccessSecret"];
    }
}
