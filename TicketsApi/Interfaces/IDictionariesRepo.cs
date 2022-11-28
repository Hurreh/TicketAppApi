using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs;
using TicketsApi.DTOs.ApiResult;

namespace TicketsApi.Interfaces
{
    public interface IDictionariesRepo
    {
        Task<ApiResult<List<CategoriesDic_DTO>>> GetCategories();
        Task<ApiResult<List<ExpertsDic_DTO>>> GetExperts();
        Task<ApiResult<List<ImpactDic_DTO>>> GetImpacts();
        Task<ApiResult<List<PriorityDic_DTO>>> GetPriorities();
        Task<ApiResult<List<StatesDic_DTO>>> GetStates();
        Task<ApiResult<List<TicketTypesDic_DTO>>> GetTicketTypes();
    }
}