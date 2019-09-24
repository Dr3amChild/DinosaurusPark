using DinosaurusPark.Exceptions;
using DinosaurusPark.Settings;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DinosaurusPark
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            string env = GetEnvironment();
            var config = ReadConfig(env);
            var settings = new AppSettings();
            config.Bind(settings);

            var host = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(config)
                .ConfigureServices(s =>
                {
                    s.AddSingleton(settings);
                })
                .Build();

            host.Services
                .GetRequiredService<IMigrationRunner>()
                .MigrateUp();

            await host.RunAsync();
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
    }
}
