using CISS411.Models.DomainModels;
using System.Linq;

namespace CISS411.Models.Miscellaneous
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
            if (!context.Events.Any())
            {
                Event firstEvent = AssembleFirstEvent();
                Book firstBook = AssembleFirstBook();
                context.Events.Add(firstEvent);
                context.Books.Add(firstBook);
            }
        }

        private static Event AssembleFirstEvent() =>
            new Event(){ Name = "It worked.", IsCurrent = true };

        private static Book AssembleFirstBook() =>
            new Book() { Title = "It worked again.", IsCurrent = true };
    }
}
