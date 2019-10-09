using DinosaurusPark.Contracts.Repositories;
using DinosaurusPark.WebApplication.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DinosaurusPark.WebApplication.Controllers
{
    public class DinosaursController : Controller
    {
        private readonly IDinoRepository _dinoRepository;

        public DinosaursController(IDinoRepository dinoRepository)
        {
            _dinoRepository = dinoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/all")]
        public async Task<IActionResult> Get(GetallRequest request)
        {
            var result = await _dinoRepository.GetAll(request.Count, request.Offset);
            return Ok(new { items = result });
        }
    }
}
