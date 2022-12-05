using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketsApi.Interfaces;
using TicketsApi.Models;

namespace TicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost, Route("authUser")]
        public async Task<IActionResult> AuthUser(AuthModel authModel)
        {
            return Ok(await _authRepo.AuthUser(authModel));
        }

        
    }
}
