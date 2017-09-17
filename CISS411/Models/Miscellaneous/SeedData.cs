using CISS411.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CISS411.Models.Miscellaneous
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(ApplicationDbContext context, 
            UserManager<Member> manager)
        {
            await Populate(context, manager);
            context.SaveChanges();
        }

        private async static Task Populate(ApplicationDbContext context,
            UserManager<Member> manager)
        {
            if (await manager.FindByEmailAsync("troberts8@cougars.ccis.edu") == null)
            {
                Member member = new Member()
                {
                    Email = "troberts8@cougars.ccis.edu",
                    UserName = "troberts8@cougars.ccis.edu",
                    FirstName = "Todd",
                    LastName = "Roberts",
                    Major = Major.NoneGiven,
                    CurrentBook = new Book() { Title = "HTML for Losers" }
                };

                var result = await manager.CreateAsync(member, "toddspassword1");
            }

            if (!context.Events.Any())
            {
                Event firstEvent = AssembleFirstEvent();
                context.Events.Add(firstEvent);
                
            }

            if (!context.Books.Any())
            {
                Book firstBook = AssembleFirstBook();
                context.Books.Add(firstBook);
            }
           
        }

        private static Event AssembleFirstEvent() =>
            new Event(){ Name = "It worked.", IsCurrent = true };

        private static Book AssembleFirstBook() =>
            new Book() { Title = "It worked again.", IsCurrent = true };

        
    }
}
