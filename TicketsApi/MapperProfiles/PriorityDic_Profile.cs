using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class PriorityDic_Profile : Profile
    {
        public PriorityDic_Profile()
        {
            CreateMap<PriorityDic, PriorityDic_DTO>();
            CreateMap<PriorityDic_DTO, PriorityDic>();
        }
    }
}
