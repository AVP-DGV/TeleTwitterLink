using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeleTwitterLink.Services.Data.Contracts;
using TeleTwitterLink.Web.Models.SearchViewModels;

namespace TeleTwitterLink.Web.Controllers
{
    public class SearchController : Controller
    {
        private ITwitterApiService twitApiService;

        public SearchController(ITwitterApiService twitApiService)
        {
            this.twitApiService = twitApiService;
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

            var searched = twitApiService.FindTwitterUserByName(model.SearchInput);

            var returnedView = new SearchResultsViewModel() { SearchResults = searched };

            return PartialView("_SearchResultPartial", returnedView);
        }
    }
}
