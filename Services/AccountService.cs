using AutoMapper;
using Carbon.Business;
using Carbon.Core.Models;
using Carbon.DataLayer.Context;
using Carbon.Models;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class AccountService : IAccountService
    {

        private static Account _account = new Account 
        {
            Id = 1,
            Amount = Calculator.TotalPaidYearly(26,2000),
            CreatedDate = DateTime.Now
        };

        private readonly IMapper _mapper;
        private readonly CarbonDbContext _context;

        public AccountService(IMapper mapper, CarbonDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetAccountDto>> Get() 
        {
            var response = new ServiceResponse<GetAccountDto>();
            try 
            {
                var account = await _context.Accounts.FirstOrDefaultAsync();
                
                response.Data = _mapper.Map<GetAccountDto>(account);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}
