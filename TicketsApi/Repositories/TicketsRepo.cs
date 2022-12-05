using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs.ApiResult;
using TicketsApi.DTOs;
using TicketsApi.Models;
using System.Linq;
using TicketsApi.Interfaces;

namespace TicketsApi.Repositories
{
    public class TicketsRepo : ITicketsRepo
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
            var tickets = await _context.Tickets.Where(x => x.Category == ticketType).ToListAsync();
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
            var tickets = await _context.Tickets.Where(x => x.Requestor == userId && x.TicketType == ticketType).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllExpertTickets(int expertId)
        {
            var tickets = await _context.Tickets.Where(x => x.Assignee == expertId).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }
        public async Task<ApiResult<List<Ticket_DTO>>> GetAllUnassignedTickets()
        {
            var tickets = await _context.Tickets.Where(x => x.Assignee == null).ToListAsync();
            var result = _mapper.Map<List<Ticket_DTO>>(tickets);
            return new ApiResult<List<Ticket_DTO>>(result, "");

        }

        public async Task<bool> CreateNewTicket(Ticket_DTO ticket)
        {
            string prefix = "";
            string previousSN = "";
            string newSN = "";
            string snSuffix = "";
            //Add serial number generator
            switch (ticket.TicketType)
            {
                case 1:
                    {
                        prefix = "REQ";

                        break;
                    }
                case 2:
                    {
                        prefix = "INC";
                        break;
                    }
                case 3:
                    {
                        prefix = "BUG";
                        break;
                    }
            }
            previousSN = await _context.Tickets.Where(x => x.SerialNumber.StartsWith(prefix))
                                                .OrderByDescending(x => x.Id)
                                                .Select(x => x.SerialNumber).FirstOrDefaultAsync();
            if (previousSN == null)
            {
                newSN = prefix + "0001";
            }
            else
            {
                previousSN = previousSN.Remove(0, 3);
                snSuffix = (int.Parse(previousSN) + 1).ToString().PadLeft(4, '0');
                newSN = prefix + snSuffix;
            }



            var newTicket = _mapper.Map<Ticket>(ticket);
            newTicket.SerialNumber = newSN;
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();

            return true;

        }
        //Wziąć pod uwagę zmianę numeru seryjnego przy zmianie rodzaju ticketu
        public async Task<bool> UpdateTicket(Ticket_DTO ticket)
        {
            //Add serial number generator
            var ticketToUpdate = await _context.Tickets.Where(x => x.SerialNumber == ticket.SerialNumber).FirstOrDefaultAsync();
            ticketToUpdate = _mapper.Map<Ticket>(ticketToUpdate);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<ApiResult<Ticket_DTO>> GetTicket(string serialNumber)
        {
            var ticket = await _context.Tickets.Where(x => x.SerialNumber.ToLower() == serialNumber.ToLower()).FirstOrDefaultAsync();
            var result = _mapper.Map<Ticket_DTO>(ticket);
            return new ApiResult<Ticket_DTO>(result, "");
        }
    }
}
