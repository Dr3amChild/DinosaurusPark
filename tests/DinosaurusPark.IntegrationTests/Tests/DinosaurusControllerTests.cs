using System.Threading.Tasks;
using DinosaurusPark.IntegrationTests.Apis;
using NUnit.Framework;

namespace DinosaurusPark.IntegrationTests.Tests
{
    public class DinosaurusControllerTests : BaseTests
    {
        private IDinosaurusControllerApi _api;

        public void Setup()
        {
            _api = GetApi<IDinosaurusControllerApi>();
        }

        [Test]
        public async Task Test1()
        {
            var result = await _api.GetAll<string>(1, 10);
            Assert.NotNull(result);
        }
    }
}