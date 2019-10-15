using DinosaurusPark.IntegrationTests.Apis;
using DinosaurusPark.IntegrationTests.Requests;
using DinosaurusPark.IntegrationTests.Responses;
using DinosaurusPark.WebApplication.Validation;
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
        public async Task Generate_ReturnsOk_IfRequestIsCorrect()
        {
            var request = new GenerationRequest
            {
                DinosaursCount = 1,
                SpeciesCount = 1,
            };

            var result = await _api.Generate<string>(request);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task Generate_ReturnsRequiredSpeciesCount_IfRequestIsCorrect()
        {
            const int expectedSpeciesCount = 3;
            var request = new GenerationRequest
            {
                DinosaursCount = 1,
                SpeciesCount = expectedSpeciesCount,
            };

            var result = await _api.Generate<GenerationResponse>(request);
            Assert.AreEqual(result.Content.Species.Count, expectedSpeciesCount);
        }

        [Test]
        public async Task Generate_ReturnsRequiredDinosaurusCount_IfRequestIsCorrect()
        {
            const int expectedDinosaursCount = 3;
            var request = new GenerationRequest
            {
                DinosaursCount = expectedDinosaursCount,
                SpeciesCount = 1,
            };

            var result = await _api.Generate<GenerationResponse>(request);
            Assert.AreEqual(result.Content.Dinosaurs.Count, expectedDinosaursCount);
        }

        [Test]
        public async Task Generate_ReturnsBadRequest_IfSpeciesCountIsNotPositive()
        {
            var request = new GenerationRequest
            {
                DinosaursCount = 1,
                SpeciesCount = -1,
            };

            var result = await _api.Generate<string>(request);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.SpeciesCountIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }

        [Test]
        public async Task Generate_ReturnsBadRequest_IfDinosaursCountIsNotPositive()
        {
            var request = new GenerationRequest
            {
                DinosaursCount = -1,
                SpeciesCount = 1,
            };

            var result = await _api.Generate<string>(request);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.DinosaursCountIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }
    }
}