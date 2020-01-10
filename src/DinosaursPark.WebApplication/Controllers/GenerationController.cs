using System;
using System.Threading.Tasks;
using DinosaursPark.Contracts.Services;
using DinosaursPark.WebApplication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DinosaursPark.WebApplication.Controllers
{
    [Route("generation")]
    public class GenerationController : Controller
    {
        private readonly IDataGenerator _generator;

        public GenerationController(IDataGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Create(GenerationRequest request)
        {
            var result = await _generator.Generate(request.Data.SpeciesCount, request.Data.DinosaursCount);
            return Ok(result);
        }
    }
}