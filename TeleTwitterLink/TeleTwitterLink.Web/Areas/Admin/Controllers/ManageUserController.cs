using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Services.Data.Contracts;

namespace TeleTwitterLink.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageUserController : Controller
    {
        private IUserManagerService userManagerService;
        private IUserService userService;
        private UserManager<User> userManager;

        public ManageUserController(IUserManagerService userManagerService, IUserService userService, UserManager<User> userManager)
        {
            this.userManagerService = userManagerService;
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult ViewAllUsers()
        {
            var users = this.userManagerService.GetAllUsers();

            return this.View(users);
        }

        public IActionResult FavouriteTwitterUsers(string id)
        {
            var favouriteTwitterUsers = this.userManagerService.TakeFavouriteTwitterUsers(id);

            return this.View(favouriteTwitterUsers);
        }

        public IActionResult FavouriteTweets(string id)
        {
            var favouriteTweets = this.userManagerService.TakeFavouriteTweetsOfUser(id);

            return this.View(favouriteTweets);
        }

        [HttpPost]
        public async Task<IActionResult> GiveAdminCredentials(string id)
        {
            var aspUser = await this.userManager.FindByIdAsync(id);

            if(aspUser == null)
            {
                return NotFound();
            }

            var result = await userManager.AddToRoleAsync(aspUser, "Admin");

            if (result.Succeeded)
            {
                return this.Ok("Added successfully.");
            } 

            return this.Ok(result.Errors);
        }
    }
}
