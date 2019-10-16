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
    public class DinosaurusControllerTests : BaseTests
    {
        private IDinosaurusControllerApi _dinosaursApi;
        private IGenerationControllerApi _generatorApi;

        [SetUp]
        public void Setup()
        {
            _dinosaursApi = GetApi<IDinosaurusControllerApi>();
            _generatorApi = GetApi<IGenerationControllerApi>();
        }

        [Test]
        public async Task GetAll_ReturnsOk_If_RequestIsCorrect()
        {
            var result = await _dinosaursApi.GetAll<string>(1, 10);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task GetAll_ReturnsFullPage_IfRequiredItemsWasGenerated()
        {
            const int expectedCount = 5;
            var generationRequest = new GenerationRequest
            {
                SpeciesCount = 1,
                DinosaursCount = expectedCount,
            };

            await _generatorApi.Generate<GenerationResponse>(generationRequest);
            var result = await _dinosaursApi.GetAll<DinosaursResponse>(expectedCount, 0);
            Assert.AreEqual(result.Content.Items.Count, expectedCount);
        }

        [Test]
        [Ignore("Need [TearDown] logic")]
        public async Task GetAll_ReturnsLessThanExpectedCount_IfThereWasGeneratedLessThanRequired()
        {
            const int actualCount = 4;
            var generationRequest = new GenerationRequest
            {
                SpeciesCount = 1,
                DinosaursCount = actualCount,
            };

            const int expectedCount = 5;
            await _generatorApi.Generate<GenerationResponse>(generationRequest);
            var result = await _dinosaursApi.GetAll<DinosaursResponse>(expectedCount, 0);
            Assert.AreEqual(result.Content.Items.Count, actualCount);
        }

        [Test]
        public async Task GetAll_ReturnsBadRequest_If_CountIsNotPositive()
        {
            var result = await _dinosaursApi.GetAll<string>(-1, 10);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.CountIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }

        [Test]
        public async Task GetAll_ReturnsBadRequest_If_OffsetIsNegative()
        {
            var result = await _dinosaursApi.GetAll<string>(1, -1);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.OffsetIsNegative, StringComparison.CurrentCulture), 0);
        }
    }
}