using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddTwitterUserController : Controller
    {
        private readonly IUserService userService;
        private ITwitterApiService twitterApiService;
        private UserManager<User> userManager;

        public AddTwitterUserController(IUserService userService, ITwitterApiService twitterApiService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.twitterApiService = twitterApiService;
        }

        //public AddTwitterUserController(IUserService userService, UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //    this.userService = userService;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TwitterUserDTO user)
        {
            user = this.twitterApiService.FindTwitterUserByTwitterId(user.TwitterUserId);

            var userID = this.userManager.GetUserId(HttpContext.User);

            this.userService.AddUser(user, userID);

            return Ok("VSICHKO tok:");
        }
    }
}
