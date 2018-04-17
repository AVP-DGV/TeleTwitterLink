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

        public IActionResult Search()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SearchResult(SearchViewModel model)
        {
            var searched = twitApiService.FindTwitterUserByName(model.SearchInput);

            var returnedView = new SearchResultsViewModel() { SearchResults = searched };

            return View(returnedView);

            //return this.View();
        }
    }
}
