using CISS411.Models.DomainModels;

namespace CISS411.ViewModels
{
    public class MemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Major Major { get; set; }
        public Book CurrentBook { get; set; }
    }
}
