using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IntopaloApi.System_for_data_governance;
using Microsoft.Extensions.Configuration;
using System;

namespace IntopaloApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
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

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}