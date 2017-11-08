using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Registration
    {
        public int UserId { get; set; }
        public Member Member { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

        
    }
}
