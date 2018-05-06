using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddTweetController : Controller
    {
        private ITweetService tweetService;
        private ITwitterApiService twitterApiService;
        private UserManager<User> userManager;

        public AddTweetController(ITweetService tweetService, ITwitterApiService twitterApiService, UserManager<User> userManager)
        {
            this.tweetService = tweetService;
            this.twitterApiService = twitterApiService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTweet(TweetDTO tweet)
        {
            //make a request to the api for the tweet
            var aspUserId = this.userManager.GetUserId(HttpContext.User);

            this.tweetService.SaveTweet(tweet, aspUserId);

            return this.Ok();
        }
    }
}
