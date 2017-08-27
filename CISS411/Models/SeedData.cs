using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace CISS411.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            Populate(context);
            context.SaveChanges();
        }

        private static void Populate(ApplicationDbContext context)
        {
            if (!context.Models.Any())
            {
                var models = AssembleModels();
                context.Models.AddRange(models);
            }
        }

        private static IEnumerable<ExampleModel> AssembleModels()
        {
            return new List<ExampleModel>
            {
                new ExampleModel { Name = "modelA" },
                new ExampleModel { Name = "modelB" },
                new ExampleModel { Name = "modelC" },
                new ExampleModel { Name = "modelD" },
                new ExampleModel { Name = "modelE" }
            };
        }
    }
}
