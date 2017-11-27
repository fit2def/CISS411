using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using CISS411.Models.Miscellaneous;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class EventViewComponent : ViewComponent
    {
        private readonly ILogger<EventViewComponent> _logger;
        private readonly ApplicationDbContext _context;
        private UserManager<Member> _userManager;

        public EventViewComponent(ILogger<EventViewComponent> logger, ApplicationDbContext context, UserManager<Member> manager)
        {
            _logger = logger;
            _context = context;
            _userManager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(IModelRepository _repository)
        {
            try
            {
                var events = await _repository.Events();
                var current = events.FirstOrDefault(e => e.IsNext);
                ViewData["UserIsRegistered"] = UserIsRegistered();
                return View(current);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve events: {ex.Message}");
                return View(new Event());
            }
        }

        private bool UserIsRegistered()
        {
            var registrations = _context.Registrations;
            var userId = _userManager.GetUserId((ClaimsPrincipal)User);
            foreach (var registration in registrations)
            {
                if (registration.UserId == userId)
                    return true;
            }
            return false;
        }
    }
}
