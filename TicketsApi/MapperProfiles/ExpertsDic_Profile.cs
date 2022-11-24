using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class ExpertsDic_Profile : Profile
    {
        public ExpertsDic_Profile()
        {
            CreateMap<ExpertsDic, ExpertsDic_DTO>();
            CreateMap<ExpertsDic_DTO, ExpertsDic>();
        }
    }
}
