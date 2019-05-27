using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FlyHigh.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlyHigh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);


            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    FlyHighContext context = services.GetRequiredService<FlyHighContext>();
         
            //    if (context.Flight.Count() == 0)
            //    {
            //        for (int i = 0; i < 20; i++) 
            //        context.Add(new Flight() { FlightNumber =1000+i});
            //        context.SaveChanges();
            //    }
            //}

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

}
