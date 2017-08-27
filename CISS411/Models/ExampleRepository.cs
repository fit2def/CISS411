using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.Models
{
    public class ExampleRepository : IExampleRepository
    {
        private ApplicationDbContext context;

        public ExampleRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<ExampleModel> Models() =>
            context.Models;
    }
}
