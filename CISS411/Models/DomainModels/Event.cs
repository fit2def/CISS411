using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
    }
}
