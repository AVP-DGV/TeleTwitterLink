using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageUserController : Controller
    {
        private IUserManagerService userManagerService;
        private IUserService userService;

        public ManageUserController(IUserManagerService userManagerService, IUserService userService)
        {
            this.userManagerService = userManagerService;
            this.userService = userService;
        }

        public IActionResult ViewAllUsers()
        {
            var users = this.userManagerService.GetAllUsers();

            return this.View(users);
        }

        public IActionResult FavouriteTwitterUsers(string id)
        {
            var favouriteTwitterUsers = this.userService.TakeFavouriteTwitterUsers(id);

            return this.View("ShowFavouriteTwitterUsers", favouriteTwitterUsers);
        }
    }
}
