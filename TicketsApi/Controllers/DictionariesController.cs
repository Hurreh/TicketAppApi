using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketsApi.Repositories;

namespace TicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : Controller
    {
        public readonly DictionariesRepo _dicRepo;
        public DictionariesController(DictionariesRepo dicRepo)
        {
            _dicRepo = dicRepo;
        }
        [HttpGet, Route("getstates")]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await _dicRepo.GetStates());
        }
        [HttpGet, Route("getpriorities")]
        public async Task<IActionResult> GetPriorities()
        {
            return Ok(await _dicRepo.GetPriorities());
        }
        [HttpGet, Route("getimpacts")]
        public async Task<IActionResult> GetImpacts()
        {
            return Ok(await _dicRepo.GetImpacts());
        }
        [HttpGet, Route("gettickettypes")]
        public async Task<IActionResult> GetTicketTypes()
        {
            return Ok(await _dicRepo.GetTicketTypes());
        }
        [HttpGet, Route("getexperts")]
        public async Task<IActionResult> GetExperts()
        {
            return Ok(await _dicRepo.GetExperts());
        }
        [HttpGet, Route("getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _dicRepo.GetCategories());
        }
    }
}
