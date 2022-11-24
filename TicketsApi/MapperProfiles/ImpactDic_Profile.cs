using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class ImpactDic_Profile : Profile
    {
        public ImpactDic_Profile()
        {
            CreateMap<ImpactDic, ImpactDic_DTO>();
            CreateMap<ImpactDic_DTO, ImpactDic>();
        }
    }
}
