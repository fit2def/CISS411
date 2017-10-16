using CISS411.Models.DomainModels;
using System.Collections.Generic;

namespace CISS411.ViewModels
{
    public class SignupViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Major Major { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
