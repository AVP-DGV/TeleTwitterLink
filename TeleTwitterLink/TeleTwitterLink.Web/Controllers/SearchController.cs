using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeleTwitterLink.Data.Models;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLink.Web.Models.SearchViewModels;

namespace TeleTwitterLink.Web.Controllers
{
    public class SearchController : Controller
    {
        private ITwitterApiService twitApiService;
        private IUsersService userService;
        private UserManager<User> userManager;

        public SearchController(ITwitterApiService twitApiService, IUsersService usersService, UserManager<User> userManager)
        {
            this.twitApiService = twitApiService;
            this.userService = usersService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchResult(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok("There were validation errors");
            }

            var searched = this.twitApiService.FindTwitterUserByName(model.SearchInput);
            this.twitApiService.GetTweetsOfUser("Dropbox");

            var returnedView = new SearchResultsViewModel() { SearchResults = searched };

            var userID = this.userManager.GetUserId(HttpContext.User);
            returnedView.SearchResults = this.userService.FilterSearchReault(returnedView.SearchResults.ToList(), userID);

            //this.twitApiService.FindTweetsUserByName();

            return PartialView("_SearchResultPartial", returnedView);
        }
    }
}
