using DinosaurusPark.DataAccess.Migrations;
using DinosaurusPark.WebApplication.Settings;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using Serilog;

namespace DinosaurusPark.WebApplication
{
    internal class Startup
    {
        private readonly AppSettings _settings;

        public Startup(AppSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(builder => builder
                    .AddPostgres()
                    .WithGlobalConnectionString(_settings.Db.ConnectionString)
                    .ScanIn(typeof(CreateTablesMigration).Assembly)
                    .For.Migrations());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseMvc(routes =>
                    {
                        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                    });

            if (_settings.Serilog.UseRequestLogging)
            {
                app.UseSerilogRequestLogging();
            }
        }
    }
}
