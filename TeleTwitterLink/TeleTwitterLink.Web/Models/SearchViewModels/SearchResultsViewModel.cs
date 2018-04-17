using System.Collections.Generic;
using TeleTwitterLink.DTO;

namespace TeleTwitterLink.Web.Models.SearchViewModels
{
    public class SearchResultsViewModel
    {
        public IEnumerable<TweeterUserDTO> SearchResults { get; set; }
    }
}
