using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs.ApiResult;
using TicketsApi.DTOs;
using TicketsApi.Models;
using System.Linq;

namespace TicketsApi.Repositories
{
    public class TicketsRepo
    {
        private readonly TicketsContext _context;
        private readonly IMapper _mapper;

        public TicketsRepo(TicketsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetTicketsOfType(int ticketType)
        {
            var tickets = await _context.Tickets.Where(x=>x.Category == ticketType).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllUserTickets(int userId)
        {
            var tickets = await _context.Tickets.Where(x => x.Requestor == userId).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllUserTicketsOfType(int userId, int ticketType)
        {
            var tickets = await _context.Tickets.Where(x => x.Requestor == userId && x.Category == ticketType).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllExpertTickets(int expertId)
        {
            var tickets = await _context.Tickets.Where(x => x.Asignee == expertId).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllUnassignedTickets()
        {
            var tickets = await _context.Tickets.Where(x => x.Asignee == null).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }

        public async Task<bool> CreateNewTicket(Ticket_DTO ticket)
        {
            //Add serial number generator
            var newTicket = _mapper.Map<Ticket>(ticket);
            newTicket.SerialNumber = "Serial Number";
            await _context.Tickets.AddAsync(newTicket);
            _context.SaveChanges();
            return true;

        }
        public async Task<bool> UpdateTicket(Ticket_DTO ticket)
        {
            ////Add serial number generator
            //var ticketToUpdate = await _context.Tickets.Where(x=>x.SerialNumber == ticket.SerialNumber).FirstOrDefaultAsync();
            //newTicket.SerialNumber = "Serial Number";
            //await _context.Tickets.AddAsync(newTicket);
            //_context.SaveChanges();
            //return true;

        }

    }
}
