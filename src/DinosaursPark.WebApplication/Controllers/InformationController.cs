using DinosaursPark.Contracts.Services;
using DinosaursPark.WebApplication.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinosaursPark.WebApplication.Controllers
{
    [Route("/information")]
    public class InformationController : Controller
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService ?? throw new ArgumentNullException(nameof(informationService));
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("park")]
        public async Task<IActionResult> LoadInfo()
        {
            var result = await _informationService.GetParkInfo<ParkInformationResponse>();
            return Ok(result);
        }

        [HttpGet("species")]
        public async Task<IActionResult> SpeciesInfo()
        {
            var items = await _informationService.GetSpeciesInfo<IReadOnlyCollection<SpeciesInformationResponse>>();
            var result = new CollectionResponse<SpeciesInformationResponse>(items);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ClearInformation()
        {
            await _informationService.DeleteAll();
            return NoContent();
        }
    }
}