using DinosaursPark.Contracts.Services;
using DinosaursPark.WebApplication.Requests;
using DinosaursPark.WebApplication.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DinosaursPark.WebApplication.Controllers
{
    public class DinosaursController : Controller
    {
        private readonly IDinosaursService _dinoService;

        public DinosaursController(IDinosaursService dinoService)
        {
            _dinoService = dinoService ?? throw new ArgumentNullException(nameof(dinoService));
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("/get")]
        public async Task<IActionResult> Get(GetByIdRequest request)
        {
            var result = await _dinoService.Get<DinosaurResponse>(request.Id);
            return Ok(result);
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAll(PagingRequest request)
        {
            var result = await _dinoService.Get<SimpleDinosaurResponse>(request.PageNumber, request.PageSize);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ClearInformation()
        {
            await _dinoService.DeleteAll();
            return NoContent();
        }
    }
}