using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class TicketTypesDic_Profile : Profile
    {
        public TicketTypesDic_Profile()
        {
            CreateMap<TicketTypesDic, TicketTypesDic_DTO>();
            CreateMap<TicketTypesDic_DTO, TicketTypesDic>();
        }
    }
}
