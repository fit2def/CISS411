using CISS411.Models.DomainModels;
using CISS411.Models.Miscellaneous;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

       
        public async Task<IActionResult> SignUp(int eventId)
        {
            Registration registration = new Registration();
            var user = await _userManager.GetUserAsync(User);
            var ev = _context.Events.FirstOrDefault(e => e.ID == eventId);
            registration.EventId = eventId;
            registration.UserId = user.Id;
            registration.Member = user;
            registration.Event = ev;
            ev.MaxSeat--;
            _context.Registrations.Add(registration);
            _context.Update(ev);
            _context.SaveChanges();
            return View(ev);
        }

        public async Task<IActionResult> DeRegister()
        {
            var ev = _context.Events.FirstOrDefault(e => e.IsNext);
            var user = await _userManager.GetUserAsync(User);
            var registration = _context.Registrations.First(r => r.UserId == user.Id);
            ev.MaxSeat++;
            _context.Update(ev);
            _context.Remove(registration);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
