using DinosaurusPark.Contracts.Services;
using DinosaurusPark.WebApplication.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DinosaurusPark.WebApplication.Controllers
{
    public class DinosaursController : Controller
    {
        private readonly IDinosaursService _dinoService;

        public DinosaursController(IDinosaursService dinoService)
        {
            _dinoService = dinoService ?? throw new ArgumentNullException(nameof(dinoService));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/all")]
        public async Task<IActionResult> Get(PagingRequest request)
        {
            var result = await _dinoService.Get(request.PageNumber, request.PageSize);
            return Ok(result);
        }
    }
}