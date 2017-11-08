using CISS411.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.Controllers.Web
{
    public class EventController:Controller
    {
        private UserManager<Member> _userManager;
        public EventController(UserManager<Member> manager)
        {
            _userManager = manager;
        }

        public IActionResult SignUp()
        {
            return View();
        }
    }
}
