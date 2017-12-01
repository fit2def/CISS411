using CISS411.Models.DomainModels;
using System;

namespace CISS411.ViewModels
{
    public class MemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Major Major { get; set; }
        public Book Book { get; set; }
        public DateTime? DateDue { get; set; }
    }
}
