using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.ViewModels
{
    public class BookViewModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
    }
}
