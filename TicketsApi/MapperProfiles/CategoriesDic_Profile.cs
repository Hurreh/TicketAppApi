using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class CategoriesDic_Profile : Profile
    {
        public CategoriesDic_Profile()
        {
            CreateMap<CategoriesDic, CategoriesDic_DTO>();
            CreateMap<CategoriesDic_DTO, CategoriesDic>();
        }
    }
}
