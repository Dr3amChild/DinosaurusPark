using DinosaursPark.IntegrationTests.Apis;
using DinosaursPark.IntegrationTests.Requests;
using DinosaursPark.IntegrationTests.Responses;
using DinosaursPark.WebApplication.Validation;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DinosaursPark.IntegrationTests.Tests
{
    public class DinosaursControllerTests : BaseTests
    {
        private IDinosaursControllerApi _dinosaursApi;
        private IGenerationControllerApi _generatorApi;

        [SetUp]
        public void Setup()
        {
            _dinosaursApi = GetApi<IDinosaursControllerApi>();
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
            var result = await _dinosaursApi.GetAll<DinosaursResponse>(1, expectedCount);
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
        public async Task GetAll_ReturnsBadRequest_If_PageSizeNotPositive()
        {
            var result = await _dinosaursApi.GetAll<string>(1, -1);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.PageSizeIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }

        [Test]
        public async Task GetAll_ReturnsBadRequest_If_PageNumberIsNegative()
        {
            var result = await _dinosaursApi.GetAll<string>(-1, 1);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.PageNumberIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }

        [Test]
        public async Task GetById_ReturnsOk_IfRequestIsCorrect()
        {
            var generationRequest = new GenerationRequest
            {
                SpeciesCount = 1,
                DinosaursCount = 1,
            };

            var generationResult = await _generatorApi.Generate<GenerationResponse>(generationRequest);
            var dinosaur = generationResult.Content.Dinosaurs.First();

            var result = await _dinosaursApi.GetById<string>(dinosaur.Id);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task GetById_ReturnsExpectedResponse_IfRequestIsCorrect()
        {
            var generationRequest = new GenerationRequest
            {
                SpeciesCount = 1,
                DinosaursCount = 1,
            };

            var generationResult = await _generatorApi.Generate<GenerationResponse>(generationRequest);
            var dinosaur = generationResult.Content.Dinosaurs.First();

            var result = await _dinosaursApi.GetById<DinosaurResponse>(dinosaur.Id);
            Assert.AreEqual(result.Content.Id, dinosaur.Id);
            Assert.AreEqual(result.Content.Name, dinosaur.Name);
        }

        [Test]
        public async Task GetById_ReturnsBadRequest_IfIdIsEmpty()
        {
            var result = await _dinosaursApi.GetById<string>(null);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.IdIsEmpty, StringComparison.CurrentCulture), 0);
        }
    }
}