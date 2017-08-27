using System.ComponentModel.DataAnnotations;

namespace CISS411.Models
{
    public class ExampleModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
