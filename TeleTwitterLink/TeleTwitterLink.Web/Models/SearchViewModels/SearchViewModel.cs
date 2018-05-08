using System.ComponentModel.DataAnnotations;

namespace TeleTwitterLink.Web.Models.SearchViewModels
{
    public class SearchViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        [DataType(DataType.Text)]
        //too many special symbols validation 
        public string SearchInput { get; set; }
    }
}
