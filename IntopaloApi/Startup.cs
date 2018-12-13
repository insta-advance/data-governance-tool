using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IntopaloApi.System_for_data_governance;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using IntopaloApi.BusinessLogic.IManagers;
using IntopaloApi.BusinessLogic.Managers;
using IntopaloApi.Data.Access.IRepositories;
using IntopaloApi.Data.Access.Repositories;
using IntopaloApi.Data.Access;

namespace IntopaloApi
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
            services.AddTransient<BaseDbContext, DataGovernanceDBContext>();
            // Comment next 2 lines for Docker, otherwise uncomment

            //services.AddDbContext<DataGovernanceDBContext>(opt => 
            //opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataGovernanceDBContext>(opt => 
            opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            
            

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
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}