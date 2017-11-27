using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CISS411.Models.DomainModels
{
    public class Registration
    {
        public string UserId { get; set; }
        [NotMapped]
        public Member Member { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        
    }
}
