using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNext { get; set; }
        public string ImageFilename { get; set; }
        public string Description { get; set; }
    }
}
