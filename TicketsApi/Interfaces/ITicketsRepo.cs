using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs;
using TicketsApi.DTOs.ApiResult;

namespace TicketsApi.Interfaces
{
    public interface ITicketsRepo
    {
        Task<bool> CreateNewTicket(Ticket_DTO ticket);
        Task<ApiResult<List<Ticket_DTO>>> GetAllExpertTickets(int expertId);
        Task<ApiResult<List<Ticket_DTO>>> GetAllTickets();
        Task<ApiResult<List<Ticket_DTO>>> GetAllUnassignedTickets();
        Task<ApiResult<List<Ticket_DTO>>> GetAllUserTickets(int userId);
        Task<ApiResult<List<Ticket_DTO>>> GetAllUserTicketsOfType(int userId, int ticketType);
        Task<ApiResult<List<Ticket_DTO>>> GetTicketsOfType(int ticketType);
        Task<bool> UpdateTicket(Ticket_DTO ticket);
    }
}