using DinosaurusPark.Contracts.Repositories;
using DinosaurusPark.Contracts.Services;
using DinosaurusPark.DataAccess;
using DinosaurusPark.DataAccess.Migrations;
using DinosaurusPark.DataAccess.Repositories;
using DinosaurusPark.Generation;
using DinosaurusPark.Services;
using DinosaurusPark.WebApplication.Filters;
using DinosaurusPark.WebApplication.Middlewares;
using DinosaurusPark.WebApplication.Settings;
using DinosaurusPark.WebApplication.Validation;
using FluentMigrator.Runner;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

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
                    .For.Migrations())
                .AddSingleton(_settings)
                .AddSingleton(_settings.Db)
                .AddScoped<DinosaurusContext>()
                .AddScoped<IDinoRepository, DinoRepository>()
                .AddScoped<IDataGenerator, DataGenerator>()
                .AddScoped<IDinosaursService, DinosaursService>()
                .AddMvc(opts => { opts.Filters.Add(new ValidationFilterAttribute()); })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PagingRequestValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Dinosaurs/Error");
            }

            app
                .UseStaticFiles()
                .UseCookiePolicy()
                .UseMiddleware(typeof(UnhandledExceptionMiddleware))
                .UseMvc(routes =>
                    {
                        routes.MapRoute(name: "default", template: "{controller=Dinosaurs}/{action=Index}/{id?}");
                    });

            if (_settings.Serilog.UseRequestLogging)
            {
                app.UseSerilogRequestLogging();
            }
        }
    }
}
