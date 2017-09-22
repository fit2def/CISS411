using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CISS411.Controllers.Web
{
    public class HomeController : Controller
    {
        IModelRepository _repository;
        
        public HomeController(IModelRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Tech Entrepreneurship";
            return View(_repository);
        }
          
    }
}
