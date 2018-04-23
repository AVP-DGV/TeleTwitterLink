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

        //bazata
        //public AddFavouriteUserController(IUsersService usersService)
        //{
        //    this.usersService = usersService;
        //}

        public AddFavouriteUserController()
        {
        }

        //[HttpPost]
        //public IActionResult AddUser()
        //{
        //    return Ok("VSICHKO tok:");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TweeterUserDTO user)
        {
            //this.usersService.AddUser(user);
            return Ok("VSICHKO tok:");
        }
    }
}
