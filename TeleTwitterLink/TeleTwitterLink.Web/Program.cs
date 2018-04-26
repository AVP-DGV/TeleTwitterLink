using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TeleTwitterLink.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var test = GetTwitterD("https://api.twitter.com/1.1/users/search.json?q=georgidimitrov5");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
