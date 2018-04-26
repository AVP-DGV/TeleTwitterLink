using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddTwitterUserController : Controller
    {
        private readonly IUsersService usersService;
        private UserManager<User> userManager;

        public AddTwitterUserController(IUsersService usersService, UserManager<User> userManager)
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
