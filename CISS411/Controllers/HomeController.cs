using Microsoft.AspNetCore.Mvc;
using CISS411.Models.Interfaces;
using CISS411.Models.DomainModels;
using System.Linq;
using System;

namespace CISS411.Controllers
{

    public class HomeController : Controller
    {
        private IModelRepository repository;

        public HomeController(IModelRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
  
    }
}
