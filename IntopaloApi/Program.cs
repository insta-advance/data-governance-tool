using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using IntopaloApi.System_for_data_governance;


namespace IntopaloApi
{
    public class Program
    {
         public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                .UseStartup<Startup>();
                

       /*static void Main(string[] args)
        {
            using (var context = new IntopaloContext()) {

                var std = new IntopaloItem()
                {
                     Name = "Bill"
                };

                context.IntopaloItems.Add(std);
                context.SaveChanges();
            }
        }*/
    }
}
