using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using CISS411.Models.Miscellaneous;

namespace CISS411
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .SeedDatabase()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
