using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class RemoveTwitterUserController : Controller
    {
        private IUserService userService;
        private UserManager<User> userManager;

        public RemoveTwitterUserController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //no aspUserID ??
        public IActionResult RemoveUser(TwitterUserDTO twitterUser)
        {
            var aspUserId = this.userManager.GetUserId(HttpContext.User);

            this.userService.RemoveTwitterUser(twitterUser.TwitterUserId, aspUserId);

            return Ok("");
        }
    }
}
