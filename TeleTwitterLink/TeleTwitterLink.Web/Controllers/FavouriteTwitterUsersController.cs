using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class FavouriteTwitterUsersController : Controller
    {
        private IUserService userService;
        private UserManager<User> userManager;

        public FavouriteTwitterUsersController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult ShowFavouriteTwitterUsers()
        {
            string aspUserId  = this.userManager.GetUserId(HttpContext.User);

            var favouriteUsers = this.userService.TakeFavouriteTwitterUsers(aspUserId);

            return this.View(favouriteUsers);
        }

    }
}
