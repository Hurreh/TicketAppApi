using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs;
using TicketsApi.DTOs.ApiResult;
using TicketsApi.Models;

namespace TicketsApi.Interfaces
{
    public interface IAuthRepo
    {
        Task<ApiResult<User_DTO>> AuthUser(AuthModel loginData);
        
    }
}