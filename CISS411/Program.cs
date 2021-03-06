﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using CISS411.ViewModels;
using CISS411.Models.DomainModels;

namespace CISS411
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EventViewModel, Event>().ReverseMap();
            });

            BuildWebHost(args)
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
