using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class EventViewComponent : ViewComponent
    {
        private readonly IModelRepository _repository;

        public EventViewComponent(IModelRepository repo)
        {
            _repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var events = await _repository.Events();
            var current = events.FirstOrDefault(e => e.IsCurrent);
            return View(current);
        }
    }
}
