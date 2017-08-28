using Microsoft.AspNetCore.Mvc;
using CISS411.Models;
using System.Linq;

namespace CISS411.Controllers
{

    public class HomeController : Controller
    {
        private IExampleRepository repository;
        public int PageSize { get; set; } = 1;

        public HomeController(IExampleRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int page = 1) =>
            View(repository.Models()
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
    }
}
