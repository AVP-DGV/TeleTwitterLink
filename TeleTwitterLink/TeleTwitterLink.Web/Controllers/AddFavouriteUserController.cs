using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Web.Controllers
{
    public class AddFavouriteUserController : Controller
    {
        //bazata
        public AddFavouriteUserController()
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(TweeterUserDTO user)
        {
            return Ok("VSICHKO tok:");
        }
    }
}
