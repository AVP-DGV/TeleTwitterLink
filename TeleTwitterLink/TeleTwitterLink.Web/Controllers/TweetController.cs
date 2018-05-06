using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class TweetController : Controller
    {
        private ITwitterApiService twitterApiService;
        private ITweetService tweetService;
        private UserManager<User> userManager;

        public TweetController(ITwitterApiService twitterApiService, ITweetService tweetService, UserManager<User> userManager)
        {
            this.twitterApiService = twitterApiService;
            this.tweetService = tweetService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Tweet()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult UserTweets(string id)
        {
            var result = this.twitterApiService.GetTweetsOfUser(id);

            var aspUserId = this.userManager.GetUserId(HttpContext.User);

            var filteredResult = this.tweetService.FilterSavedTweets(result, aspUserId);

            return this.View("UserTweets", filteredResult);
        }
    }
}
