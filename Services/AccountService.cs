using AutoMapper;
using Carbon.Business;
using Carbon.Core.Models;
using Carbon.Models;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using System;
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

        public AccountService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetAccountDto>> Get() 
        {
            var response = new ServiceResponse<GetAccountDto>();

            response.Success = true;            
            response.Data =  _mapper.Map<GetAccountDto>(_account);
            return response;
        }
    }
}
