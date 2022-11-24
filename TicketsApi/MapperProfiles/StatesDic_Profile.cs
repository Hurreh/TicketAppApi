using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class StatesDic_Profile : Profile
    {
        public StatesDic_Profile()
        {
            CreateMap<StatesDic, StatesDic_DTO>();
            CreateMap<StatesDic_DTO, StatesDic>();
        }
    }
}
