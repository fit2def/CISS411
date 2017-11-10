using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNext { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
        public string Description { get; set; }
        public int MaxSeat { get; set; }
    }
}
