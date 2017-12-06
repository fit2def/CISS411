using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using CISS411.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        private readonly ILogger<BookViewComponent> _logger;
        private UserManager<Member> _manager;

        public BookViewComponent(ILogger<BookViewComponent> logger, UserManager<Member> manager)
        {
            _logger = logger;
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(IModelRepository _repository)
        {
            try
            {
                var books = await _repository.Books();
                var user = await _manager.GetUserAsync((ClaimsPrincipal)User);
                var current = books.FirstOrDefault(b => b.IsCurrent);
                CheckoutViewModel vm = new CheckoutViewModel
                {
                    Book = current,
                    Member = user
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve books: {ex.Message}");
                return View(new Book());
            }
        }
    }
}
