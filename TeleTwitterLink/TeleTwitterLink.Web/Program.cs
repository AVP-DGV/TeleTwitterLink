using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using TeleTwitterLink.Services.Data;

namespace TeleTwitterLink.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
            var test = GetTwitterD("https://api.twitter.com/1.1/users/search.json?q=georgidimitrov5");
            System.Console.WriteLine(test);
=======
            //var test = GetTwitterD("https://api.twitter.com/1.1/users/search.json?q=georgidimitrov5");
            //System.Console.WriteLine(test);
>>>>>>> ef515ef73085f614b5cfebd17db9c1c6abd29a47

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static string GetTwitterD(string resourceurl)
        {
            var consumerkey = "ecOn11Cj0GizRi1jqwDYsID6o";
            var consumersecret = "o8hCuBXD5cuxPuPHjpr1AHaJMoUDIYXDXn4qk0i7BGRjEeQdI1";
            var accesstoken = "728683079326420992-gE1AVS9pYuCBiHXyfAQMGoEy8i1WkHG";
            var accesssecret = "XRq3cVLPvPROQdTqnDmoI9FXbdNVHLhFqfeoMnwFN6T9t";

            TwitterApiCall timelineTweets = new TwitterApiCall(consumerkey, consumersecret, accesstoken, accesssecret);
            return timelineTweets.GetTwitterData(resourceurl.Trim());
        }
    }
}
