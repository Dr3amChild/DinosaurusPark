using DinosaurusPark.DataAccess;
using DinosaurusPark.WebApplication.Exceptions;
using DinosaurusPark.WebApplication.Settings;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Polly;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DinosaurusPark.WebApplication
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            string env = GetEnvironment();
            var config = ReadConfig(env);
            var settings = new AppSettings();
            config.Bind(settings);

            InitializeLogger(settings);
            var host = BuildWebHost(config, settings);

            Policy retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetry(3, attempt => TimeSpan.FromMilliseconds(5000));

            retryPolicy.Execute(() =>
            {
                var ctx = host.Services.GetService<DinosaurusContext>();
                ctx.Database.EnsureCreated();
            });

            host.Services
                .GetRequiredService<IMigrationRunner>()
                .MigrateUp();

            await host.RunAsync();
        }

        private static IWebHost BuildWebHost(IConfigurationRoot config, AppSettings settings)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .UseSerilog()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureServices(s =>
                {
                    s.AddSingleton(settings);
                })
                .Build();
        }

        private static string GetEnvironment()
        {
            const string envName = "ASPNETCORE_ENVIRONMENT";
            var env = Environment.GetEnvironmentVariable(envName);
            if (string.IsNullOrWhiteSpace(env))
                throw new ApplicationStartupException($"Environment variable \"{envName}\" is not specified");
            return env;
        }

        private static IConfigurationRoot ReadConfig(string env)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: false)
                .AddEnvironmentVariables("DINOPARK_")
                .Build();
        }

        private static void InitializeLogger(AppSettings settings)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Console(
                    settings.Serilog.Level,
                    "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
