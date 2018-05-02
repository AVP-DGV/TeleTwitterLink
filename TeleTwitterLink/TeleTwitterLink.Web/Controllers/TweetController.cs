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
        private IUserService userService;
        private UserManager<User> userManager;

        public TweetController(ITwitterApiService twitterApiService, IUserService userService, UserManager<User> userManager)
        {
            this.twitterApiService = twitterApiService;
            this.userService = userService;
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

            return this.PartialView("_UserTweetPartial", result);
        }
    }
}
