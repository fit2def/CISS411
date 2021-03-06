﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CISS411.Models.Interfaces;
using CISS411.Models.Miscellaneous;
using CISS411.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace CISS411
{


    public class Startup
    {
        IConfigurationRoot _config;
        IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            _config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISettings, Settings>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IModelRepository, ModelRepository>();

            services.AddIdentity<Member, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireDigit = false;

            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

            services.AddLogging();
            services.AddMvc(config =>
            {
                //uncomment the line below once HTTPS has actually been set up.
                //if (_env.IsProduction()) config.Filters.Add(new RequireHttpsAttribute());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStatusCodePages();

            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }
      
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
