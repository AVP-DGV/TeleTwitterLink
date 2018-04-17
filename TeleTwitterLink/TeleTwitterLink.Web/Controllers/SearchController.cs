using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleTwitterLink.Web.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Search(string value)
        {
            return this.View();
        }
    }
}
