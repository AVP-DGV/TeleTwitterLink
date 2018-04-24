using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.DTO;
using TeleTwitterLink.Infrastructure.Providers;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddFavouriteUserController : Controller
    {
        private readonly IUsersService usersService;

        public AddFavouriteUserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TwitterUserDTO user)
        {
            this.usersService.AddUser(user);
            return Ok("VSICHKO tok:");
        }
    }
}
