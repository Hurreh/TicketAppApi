using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketsApi.DTOs;
using TicketsApi.Interfaces;

namespace TicketsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {

        public readonly ITicketsRepo _ticketsRepo;
        public TicketsController(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }

        [HttpGet, Route("getallexperttickets")]
        public async Task<IActionResult> GetAllExpertTickets(int expertId)
        {
            return Ok(await _ticketsRepo.GetAllExpertTickets(expertId));
        }

        [HttpGet, Route("getalltickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok(await _ticketsRepo.GetAllTickets());
        }
        [HttpGet, Route("getallunassignedtickets")]
        public async Task<IActionResult> GetAllUnassignedTickets()
        {
            return Ok(await _ticketsRepo.GetAllUnassignedTickets());
        }
        [HttpGet, Route("getallusertickets")]
        public async Task<IActionResult> GetAllUserTickets(int userId)
        {
            return Ok(await _ticketsRepo.GetAllUserTickets(userId));
        }
        [HttpGet, Route("getalluserticketsoftype")]
        public async Task<IActionResult> GetAllUserTicketsOfType(int userId, int ticketType)
        {
            return Ok(await _ticketsRepo.GetAllUserTicketsOfType(userId, ticketType));
        }
        [HttpGet, Route("getticketsoftype")]
        public async Task<IActionResult> GetTicketsOfType(int ticketType)
        {
            return Ok(await _ticketsRepo.GetTicketsOfType(ticketType));
        }
        [HttpPost, Route("updateticket")]
        public async Task<IActionResult> UpdateTicket(Ticket_DTO ticket)
        {
            return Ok(await _ticketsRepo.UpdateTicket(ticket));
        }
        [HttpPost, Route("createnewticket")]
        public async Task<IActionResult> CreateNewTicket(Ticket_DTO ticket)
        {
            return Ok(await _ticketsRepo.CreateNewTicket(ticket));
        }
        [HttpGet, Route("getticket")]
        public async Task<IActionResult> GetTicker(string serialNumber)
        {
            return Ok(await _ticketsRepo.GetTicket(serialNumber));
        }
    }
}
