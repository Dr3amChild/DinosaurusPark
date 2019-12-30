using AutoMapper;
using DinosaursPark.Contracts.Repositories;
using DinosaursPark.Contracts.Services;
using DinosaursPark.DataAccess;
using DinosaursPark.DataAccess.Migrations;
using DinosaursPark.DataAccess.Repositories;
using DinosaursPark.Generation;
using DinosaursPark.Services;
using DinosaursPark.WebApplication.Filters;
using DinosaursPark.WebApplication.Mapping;
using DinosaursPark.WebApplication.Middlewares;
using DinosaursPark.WebApplication.Settings;
using DinosaursPark.WebApplication.Validation;
using FluentMigrator.Runner;
using FluentValidation.AspNetCore;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using React.AspNet;
using Serilog;
using System;

namespace DinosaursPark.WebApplication
{
    internal class Startup
    {
        private readonly AppSettings _settings;
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env, AppSettings settings)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
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
                .AddAutoMapper(typeof(AppMappingProfile))
                .AddFluentMigratorCore()
                .ConfigureRunner(builder => builder
                    .AddPostgres()
                    .WithGlobalConnectionString(_settings.Db.ConnectionString)
                    .ScanIn(typeof(CreateTablesMigration).Assembly)
                    .For.Migrations())
                .AddSingleton(_settings)
                .AddSingleton(_settings.Db)
                .AddSingleton(_settings.Files)
                .AddScoped<DinosaursContext>()
                .AddScoped<IDinoRepository, DinoRepository>()
                .AddScoped<IInformationRepository, InformationRepository>()
                .AddSingleton(_env.ContentRootFileProvider)
                .AddScoped<IImageProvider, ImageProvider>()
                .AddScoped<IDataGenerator, DataGenerator>()
                .AddScoped<IDinosaursService, DinosaursService>()
                .AddScoped<IInformationService, InformationService>()
                .AddMvc(opts => { opts.Filters.Add(new ValidationFilterAttribute()); })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PagingRequestValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddReact()
                .AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                .UseReact(config =>
                {
                    config.LoadBabel = true;
                })
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapControllerRoute("default", "{controller=Dinosaurs}/{action=Index}/{id?}");
                });

            if (_settings.Serilog.UseRequestLogging)
            {
                app.UseSerilogRequestLogging();
            }
        }
    }
}
