using System.ComponentModel.DataAnnotations;

namespace CISS411.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
