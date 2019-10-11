using Microsoft.Extensions.Configuration;
using Refit;

namespace DinosaurusPark.IntegrationTests.Tests
{
    public abstract class BaseTests
    {
        protected BaseTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json", optional: false)
                .AddEnvironmentVariables("DINOPARK_TESTS_")
                .Build();

            config.Bind(Settings);
        }

        protected Settings Settings { get; } = new Settings();

        protected TApi GetApi<TApi>() => RestService.For<TApi>(Settings.Api.Uri);
    }
}