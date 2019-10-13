using DinosaurusPark.IntegrationTests.Apis;
using DinosaurusPark.IntegrationTests.Requests;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DinosaurusPark.IntegrationTests.Tests
{
    public class GenerationControllerTests : BaseTests
    {
        private IGenerationControllerApi _api;

        [SetUp]
        public void Setup()
        {
            _api = GetApi<IGenerationControllerApi>();
        }

        [Test]
        public async Task Generate_Returns_OkStatusCode()
        {
            var request = new GenerationRequest
            {
                DinosaursCount = 1,
                SpeciesCount = 1,
            };

            var result = await _api.Generate<string>(request);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
    }
}