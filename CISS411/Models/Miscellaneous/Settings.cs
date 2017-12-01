using CISS411.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CISS411.Models.Miscellaneous
{
    public class Settings : ISettings
    {
        IConfigurationRoot _config;
        IHostingEnvironment _env;

        public Settings(IHostingEnvironment env)
        {
            _env = env;
            _config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public int CheckoutDuration()
        {
            return int.Parse(_config["Days:CheckoutDuration"]);
        }
    }
}

