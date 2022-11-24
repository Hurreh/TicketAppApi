using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs;
using TicketsApi.DTOs.ApiResult;
using TicketsApi.Models;

namespace TicketsApi.Repositories
{
    public class DictionariesRepo
    {
        private readonly TicketsContext _context;
        private readonly IMapper _mapper;

        public DictionariesRepo(TicketsContext context, IMapper mapper)
        {   
            _context= context;
            _mapper= mapper;
        }


        public async Task<ApiResult<List<StatesDic_DTO>>> GetStates()
        {
            var states = await _context.StatesDics.ToListAsync();
            var result = _mapper.Map<List<StatesDic_DTO>>(states);
            return new ApiResult<List<StatesDic_DTO>>(result, "");

        }
        public async Task<ApiResult<List<CategoriesDic_DTO>>> GetCategories()
        {
            var categories = await _context.CategoriesDics.ToListAsync();
            var result = _mapper.Map<List<CategoriesDic_DTO>>(categories);
            return new ApiResult<List<CategoriesDic_DTO>>(result, "");

        }
        public async Task<ApiResult<List<PriorityDic_DTO>>> GetPriorities()
        {
            var priorities = await _context.PriorityDics.ToListAsync();
            var result = _mapper.Map<List<PriorityDic_DTO>>(priorities);
            return new ApiResult<List<PriorityDic_DTO>>(result, "");

        }
        public async Task<ApiResult<List<ImpactDic_DTO>>> GetImpacts()
        {
            var impacts = await _context.ImpactDics.ToListAsync();
            var result = _mapper.Map<List<ImpactDic_DTO>>(impacts);
            return new ApiResult<List<ImpactDic_DTO>>(result, "");

        }
        public async Task<ApiResult<List<ExpertsDic_DTO>>> GetExperts()
        {
            var experts = await _context.ExpertsDics.ToListAsync();
            var result = _mapper.Map<List<ExpertsDic_DTO>>(experts);
            return new ApiResult<List<ExpertsDic_DTO>>(result, "");

        }
    }
}
