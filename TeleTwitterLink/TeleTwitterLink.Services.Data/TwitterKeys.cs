using Microsoft.Extensions.Configuration;

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

        //public string ConsumerKey { get; set; }
        //public string ConsumerSecret { get; set; }
        //public string AccessToken { get; set; }
        //public string AccessSecret { get; set; }
    }
}
