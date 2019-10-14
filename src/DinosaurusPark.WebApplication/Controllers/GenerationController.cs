using System;
using System.Threading.Tasks;
using DinosaurusPark.Contracts;
using DinosaurusPark.WebApplication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DinosaurusPark.WebApplication.Controllers
{
    [Route("generation")]
    public class GenerationController : Controller
    {
        private readonly IDataGenerator _generator;

        public GenerationController(IDataGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
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
