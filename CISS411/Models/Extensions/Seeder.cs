using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CISS411.Models.Miscellaneous;
using CISS411.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CISS411.Models.Extensions
{
    public static class Seeder
    {
        public static IWebHost SeedDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var manager = services.GetRequiredService<UserManager<Member>>();
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    Task.WaitAll(SeedData.EnsurePopulated(context, manager));
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            return host;
        }
    }
}
