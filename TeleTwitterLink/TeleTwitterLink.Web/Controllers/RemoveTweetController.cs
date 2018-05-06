using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class RemoveTweetController : Controller
    {
        private ITweetService tweetService;
        private ITwitterApiService twitterApiService;
        private UserManager<User> userManager;

        public RemoveTweetController(ITweetService tweetService, ITwitterApiService twitterApiService, UserManager<User> userManager)
        {
            this.tweetService = tweetService;
            this.twitterApiService = twitterApiService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveTweet(TweetDTO tweetDTO)
        {
            //validate if the tweet id is correct
            var aspUserId = this.userManager.GetUserId(HttpContext.User);

            this.tweetService.RemoveTweet(tweetDTO.TweetId, aspUserId);

            return Ok();
        }
    }
}
