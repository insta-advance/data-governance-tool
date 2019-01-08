﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            services.AddTransient<IFieldsManager, FieldsManager>();    
            services.AddTransient<IFieldsRepository, FieldsRepository>();
            services.AddTransient<BaseDbContext, DataGovernanceDBContext>();
            services.AddTransient<IKeyRelationshipsManager, KeyRelationshipsManager>();
            services.AddTransient<IKeyRelationshipsRepository, KeyRelationshipsRepository>();
            // Comment next 2 lines for Docker, otherwise uncomment

            services.AddDbContext<DataGovernanceDBContext>(opt => 
            // NOT Docker
            // opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            // Docker
            opt.UseNpgsql(Configuration.GetConnectionString("DockerCommandsConnectionString")));

            //Use in development if sql if pg is too much hassle.
            //opt.UseSqlite("Data source=DataGovernanceTool.db"));
            // Docker SQL SERVER  Comment next 3 lines if you don't run in Docker
            
            //var connection = @"Server=db;Database=master;User=sa;Password=Intopal0;";
            //services.AddDbContext<DataGovernanceDBContext>(
            //    options => options.UseSqlServer(connection));
        
            /* Register CORS service. */
            services.AddCors();

            services.AddMvc(
                options =>
                {
                    options.OutputFormatters.RemoveType<JsonOutputFormatter>();
                    options.OutputFormatters.Add(
                        new JsonOutputFormatter(
                            new JsonSerializerSettings() {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                NullValueHandling = NullValueHandling.Ignore
                            },
                            System.Buffers.ArrayPool<char>.Shared)
                    );
                }
            )
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

            /* Enable CORS allow usage only  */
            app.UseCors(builder =>
                builder.WithOrigins(Configuration.GetValue<string>("AllowedHosts")));
        }
    }
}