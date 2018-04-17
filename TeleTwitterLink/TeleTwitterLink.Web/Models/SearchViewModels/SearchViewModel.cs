using System.ComponentModel.DataAnnotations;

namespace TeleTwitterLink.Web.Models.SearchViewModels
{
    public class SearchViewModel
    {
        [Required]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string SearchInput { get; set; }
    }
}
