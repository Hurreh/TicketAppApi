using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsApi.DTOs.ApiResult;
using TicketsApi.DTOs;
using TicketsApi.Models;
using TicketsApi.Interfaces;
using AutoMapper;

namespace TicketsApi.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly TicketsContext _context;
        private readonly IMapper _mapper;
        public AuthRepo(TicketsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResult<User_DTO>> AuthUser(AuthModel loginData)
        {
            User_DTO userInfo = new User_DTO();
            var findUser = await _context.Users.FirstOrDefaultAsync(x=>x.Login == loginData.Login && x.Password == loginData.Password);
            if (findUser != null)
            {
                var result = _mapper.Map<User_DTO>(findUser);
                return new ApiResult<User_DTO>(result, "");
            }
            return new ApiResult<User_DTO>(null, "User not found");
        }
        

    }
}
