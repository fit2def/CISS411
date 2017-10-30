using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        private readonly ILogger<BookViewComponent> _logger;

        public BookViewComponent(ILogger<BookViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync(IModelRepository _repository)
        {
            try
            {
                var books = await _repository.Books();
                var current = books.FirstOrDefault(b => b.IsCurrent);
                return View(current);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to retrieve books: {ex.Message}");
                return View(new Book());
            }
        }
    }
}
