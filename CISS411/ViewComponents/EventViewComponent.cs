using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class EventViewComponent : ViewComponent
    {
        private readonly ILogger<EventViewComponent> _logger;

        public EventViewComponent(ILogger<EventViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync(IModelRepository _repository)
        {
            try
            {
                var events = await _repository.Events();
                var current = events.FirstOrDefault(e => e.IsNext);
                return View(current);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve eventss: {ex.Message}");
                return View(new Event());
            }
        }
    }
}
