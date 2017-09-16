using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Book
    {
        [Key]
        public string Title { get; set; }
        public bool IsCurrent { get; set; }
    }
}
