using DinosaursPark.DataAccess;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Refit;

namespace DinosaursPark.IntegrationTests.Tests
{
    public abstract class BaseTests
    {
        private readonly Settings _settings = new Settings();
        private readonly DinosaursContext _context;

        protected BaseTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", optional: false)
                .AddEnvironmentVariables("DINOPARK_TESTS_")
                .Build();

            config.Bind(_settings);

            _context = new DinosaursContext(_settings.Db);
        }

        protected TApi GetApi<TApi>() => RestService.For<TApi>(_settings.Api.Uri);

        protected void ClearDatabase()
        {
            _context.Information.RemoveRange(_context.Information);
            _context.Dinosaurs.RemoveRange(_context.Dinosaurs);
            _context.Species.RemoveRange(_context.Species);
            _context.SaveChanges();
        }

        [TearDown]
        protected void TearDown()
        {
            ClearDatabase();
        }
    }
}