using DinosaurusPark.IntegrationTests.Apis;
using DinosaurusPark.WebApplication.Validation;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DinosaurusPark.IntegrationTests.Tests
{
    public class DinosaurusControllerTests : BaseTests
    {
        private IDinosaurusControllerApi _api;

        [SetUp]
        public void Setup()
        {
            _api = GetApi<IDinosaurusControllerApi>();
        }

        [Test]
        public async Task GetAll_ReturnsOk_If_RequestIsCorrect()
        {
            var result = await _api.GetAll<string>(1, 10);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public async Task GetAll_ReturnsBadRequest_If_CountIsNotPositive()
        {
            var result = await _api.GetAll<string>(-1, 10);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.CountIsNegativeOrZero, StringComparison.CurrentCulture), 0);
        }

        [Test]
        public async Task GetAll_ReturnsBadRequest_If_OffsetIsNegative()
        {
            var result = await _api.GetAll<string>(1, -1);
            Assert.AreEqual(result.StatusCode, HttpStatusCode.BadRequest);
            Assert.GreaterOrEqual(result.Error.Content.IndexOf(ErrorCodes.OffsetIsNegative, StringComparison.CurrentCulture), 0);
        }
    }
}