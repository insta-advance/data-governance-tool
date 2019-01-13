using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataGovernanceTool
{
    public class Program
    {
        //private static Container _container;

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
             using (var context = new DataGTContext()) {

                 var std = new DataGTItem()
                 {
                      Name = "Bill"
                 };

                 context.DataGTItems.Add(std);
                 context.SaveChanges();
             }
         }*/

        //private static void ConfigureDependencyInjection()
        //{
        //    _container = new Container();
        //    _container.Configure(config =>
        //    {
        //        config.Scan(_ =>
        //        {
        //            // Scan all assemblies referenced by the root project.
        //            // Only Backbone.* and [ServiceName].* assemblies will be there.
        //            _.AssembliesFromApplicationBaseDirectory();
        //            _.WithDefaultConventions();

        //            // Uses ServiceRegistry class for custom mapping.
        //            // E.g. GrpcService instance and database context creation.
        //            _.LookForRegistries();
        //        });

        //        // This will be resolved by IServiceProvider in [ServiceName]Impl constructor.
        //        var serviceCollection = new ServiceCollection();
        //        serviceCollection.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

        //        config.Populate(serviceCollection);
        //    });
        //}
    }
}
