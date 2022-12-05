using AutoMapper;
using TicketsApi.DTOs;
using TicketsApi.Models;

namespace TicketsApi.MapperProfiles
{
    public class User_Profile : Profile
    {
        public User_Profile()
        {
            CreateMap<User, User_DTO>();
            CreateMap<User_DTO, User>();
        }
    }
}
