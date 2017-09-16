using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CISS411.Models.Miscellaneous
{
    public class ModelRepository : IModelRepository
    {
        private ApplicationDbContext _context;

        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> Events()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<List<Book>> Books()
        {
            return await _context.Books.ToListAsync();
        }

        public void AddEvent(Event anEvent)
        {
            _context.Add(anEvent);
        }

        public void AddBook(Book book)
        {
            _context.Add(book);
        }

        public  async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; //saving returns # rows affected.
        }
    }
}
