using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class Ticket_Profile : Profile
    {

        public Ticket_Profile()
        {
            CreateMap<Ticket, Ticket_DTO>();
            CreateMap<Ticket_DTO, Ticket>();
        }
    }
}
