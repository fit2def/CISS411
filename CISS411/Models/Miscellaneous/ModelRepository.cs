using CISS411.Models.DomainModels;
using CISS411.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CISS411.Models.Miscellaneous
{
    public class ModelRepository : IModelRepository
    {
        private ApplicationDbContext context;

        public ModelRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public async Task<List<Event>> Events()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<List<Book>> Books()
        {
            return await context.Books.ToListAsync();
        }
            
    }
}
