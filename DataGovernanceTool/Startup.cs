using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using DataGovernanceTool.BusinessLogic.IManagers;
using DataGovernanceTool.BusinessLogic.Managers;
using DataGovernanceTool.Data.Access.IRepositories;
using DataGovernanceTool.Data.Access.Repositories;
using DataGovernanceTool.Data.Access;
using GlobalErrorHandling.Extensions;

namespace DataGovernanceTool
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Configure dependency injections.
            services.AddTransient<IDatabasesManager, DatabasesManager>();
            services.AddTransient<IDatabasesRepository, DatabasesRepository>();
            services.AddTransient<ISchemasManager, SchemasManager>();
            services.AddTransient<ISchemasRepository, SchemasRepository>();
            services.AddTransient<ICollectionsManager, CollectionsManager>();
            services.AddTransient<ICollectionsRepository, CollectionsRepository>();
            services.AddTransient<IDatastoresManager, DatastoresManager>();
            services.AddTransient<IDatastoresRepository, DatastoresRepository>();
            services.AddTransient<IUnstructuredFilesManager, UnstructuredFilesManager>();
            services.AddTransient<IUnstructuredFilesRepository, UnstructuredFilesRepository>();
            services.AddTransient<IStructuredFilesManager, StructuredFilesManager>();
            services.AddTransient<IStructuredFilesRepository, StructuredFilesRepository>();
            services.AddTransient<ITablesManager, TablesManager>();
            services.AddTransient<ITablesRepository, TablesRepository>();
            services.AddTransient<BaseDbContext, DataGovernanceDBContext>();
            // Comment next 2 lines for Docker, otherwise uncomment

            services.AddDbContext<DataGovernanceDBContext>(opt => 
            // NOT Docker
            opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            // Docker
            //opt.UseNpgsql(Configuration.GetConnectionString("DockerCommandsConnectionString")));

            //Use in development if sql if pg is too much hassle.
            //opt.UseSqlite("Data source=DataGovernanceTool.db"));

            
            

        // Docker SQL SERVER  Comment next 3 lines if you don't run in Docker
        
        //var connection = @"Server=db;Database=master;User=sa;Password=Intopal0;";
        //services.AddDbContext<DataGovernanceDBContext>(
        //    options => options.UseSqlServer(connection));
        

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            //app.ConfigureExceptionHandler();
            app.ConfigureCustomExceptionMiddleware();
            app.UseMvc();
        }
    }
}