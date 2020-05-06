using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common.Clients;
using Common.Repositories;
using Common.Settings;
using CSC4151_ProfileService.ASB;
using CSC4151_ProfileService.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CSC4151_ProfileService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Settings
            var settings = new SqlSettings();
            Configuration.Bind("SQL", settings);
            services.AddSingleton<SqlSettings>(settings);

            var config = new Settings();
            Configuration.Bind("Configuration", config);
            services.AddSingleton<ISettings>(config);

            // Repositories
            services.AddSingleton<IProfileRepository, ProfileRepository>();
            
            // Clients
            services.AddSingleton<SqlClient>();

            // Handlers
            services.AddSingleton<CreateProfileHandler>();

            // ServiceBus
            services.AddSingleton<ServiceBusClient>();
            services.AddHostedService<EndpointIntializer>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
