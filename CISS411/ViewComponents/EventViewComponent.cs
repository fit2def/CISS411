using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        private readonly IModelRepository _repository;

        public BookViewComponent(IModelRepository repo)
        {
            _repository = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _repository.Books();
            var current = books.FirstOrDefault(b => b.IsCurrent);
            return View(current);
        }
    }
}
