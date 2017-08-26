using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CISS411
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Todd Roberts 
            //Michelle Meyer sucks
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
