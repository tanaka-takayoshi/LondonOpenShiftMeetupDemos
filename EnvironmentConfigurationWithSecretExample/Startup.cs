using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnvironmentConfigurationWithSecretExample.Models;

namespace EnvironmentConfigurationWithSecretExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.Configure<MyOption>(Configuration.GetSection("myoption"));
            services.Configure<MyOption>(myOption =>
            {
                myOption.EnvironmentName = "Development";
            });
            //You can configure DB connection here.
            services.AddMvc();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.Configure<MyOption>(Configuration.GetSection("myoption"));
            services.Configure<MyOption>(myOption =>
            {
                myOption.EnvironmentName = "Production";
            });
            //You can configure DB connection here.
            services.AddMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MyOption>(Configuration);
            services.AddMvc();
        }

        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureProduction(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}