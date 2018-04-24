using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TeleTwitterLink.Data.Models;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddFavouriteUserController : Controller
    {
        private readonly IUsersService usersService;
        private UserManager<User> userManager;

        public AddFavouriteUserController(IUsersService usersService, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.usersService = usersService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TwitterUserDTO user)
        {
            var userID = this.userManager.GetUserId(HttpContext.User);

            this.usersService.AddUser(user, userID);

            return Ok("VSICHKO tok:");
        }
    }
}
