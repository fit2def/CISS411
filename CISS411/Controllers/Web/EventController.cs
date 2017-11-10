using CISS411.Models.DomainModels;
using CISS411.Models.Miscellaneous;
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
        private ApplicationDbContext _context;

        public EventController(UserManager<Member> manager, ApplicationDbContext context)
        {
            _userManager = manager;
            _context = context;
        }

        public async Task<IActionResult> SignUp(string eventId)
        {
            Registration registration = new Registration();
            var user = await _userManager.GetUserAsync(User);
            var ev = _context.Events.FirstOrDefault(e => e.ID.ToString() == eventId);
            registration.EventId = int.Parse(eventId);
            registration.UserId = int.Parse(user.Id);
            registration.Member = user;
            registration.Event = ev;
            _context.Registrations.Add(registration);
            _context.SaveChanges();
            return View(ev);
        }
    }
}
