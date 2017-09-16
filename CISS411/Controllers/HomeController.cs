using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CISS411.Controllers
{
    public class HomeController : Controller
    {
        IModelRepository _repository;
        
        public HomeController(IModelRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() =>
            View(_repository);   
    }
}
