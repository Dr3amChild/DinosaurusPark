using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DinosaursPark.IntegrationTests.Apis;
using DinosaursPark.IntegrationTests.Requests;
using DinosaursPark.WebApplication.Responses;
using NUnit.Framework;

namespace DinosaursPark.IntegrationTests.Tests
{
    public class InformationControllerTests : BaseTests
    {
        private IInformationControllerApi _informationApi;
        private IGenerationControllerApi _generationApi;

        [SetUp]
        public void Setup()
        {
            _informationApi = GetApi<IInformationControllerApi>();
            _generationApi = GetApi<IGenerationControllerApi>();
            ClearDatabase();
        }

        [Test]
        public async Task GetParkInfo_ReturnsNotFound_IfDataNotGenerated()
        {
            var result = await _informationApi.GetParkInfo<string>();
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound, result.Error?.Content ?? result.Content);
        }

        [Test]
        public async Task GetParkInfo_ReturnsOk_IfDataGenerated()
        {
            await _generationApi.Generate<string>(new GenerationRequest { SpeciesCount = 1, DinosaursCount = 10 });
            var result = await _informationApi.GetParkInfo<string>();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, result.Error?.Content ?? result.Content);
        }

        [Test]
        public async Task GetSpeciesInfo_ReturnsOk_IfDataNotGenerated()
        {
            var result = await _informationApi.GetSpeciesInfo<string>(1, 10);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, result.Error?.Content ?? result.Content);
        }

        [Test]
        public async Task GetSpeciesInfo_ReturnsEmptyResponse_IfDataNotGenerated()
        {
            var result = await _informationApi.GetSpeciesInfo<CollectionResponse<ParkInformationResponse>>(1, 10);
            Assert.AreEqual(0, result.Content.Items.Count);
        }

        [Test]
        public async Task GetSpeciesInfo_ReturnsOk_IfDataGenerated()
        {
            const int expected = 10;
            await _generationApi.Generate<string>(new GenerationRequest { SpeciesCount = 1, DinosaursCount = expected });
            var result = await _informationApi.GetSpeciesInfo<string>(1, expected);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode, result.Error?.Content ?? result.Content);
        }

        [Test]
        public async Task GetSpeciesInfo_ReturnsExpectedSpeciesCount_IfDataGenerated()
        {
            const int expectedSpeciesCount = 2;
            await _generationApi.Generate<string>(new GenerationRequest { SpeciesCount = expectedSpeciesCount, DinosaursCount = 5 });
            var result = await _informationApi.GetSpeciesInfo<CollectionResponse<SpeciesInformationResponse>>(1, 5);
            Assert.AreEqual(expectedSpeciesCount, result.Content.Items.Count);
        }

        [Test]
        public async Task GetSpeciesInfo_ReturnsExpectedDinosaursCount_IfDataGenerated()
        {
            const int expectedDinosaursCount = 3;
            await _generationApi.Generate<string>(new GenerationRequest { SpeciesCount = 1, DinosaursCount = expectedDinosaursCount });
            var result = await _informationApi.GetSpeciesInfo<CollectionResponse<SpeciesInformationResponse>>(1, 10);
            Assert.AreEqual(expectedDinosaursCount, result.Content.Items.First().Count);
        }
    }
}