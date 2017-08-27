using Microsoft.AspNetCore.Mvc;
using CISS411.Models;

namespace CISS411.Controllers
{

    public class HomeController : Controller
    {
        private IExampleRepository repository;

        public HomeController(IExampleRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Models());
    }
}
