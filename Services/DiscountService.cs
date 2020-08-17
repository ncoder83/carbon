using AutoMapper;
using Carbon.Core.Models;
using Carbon.Models;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class DiscountService : IDiscountService
    {
        private static List<Discount> discounts = new List<Discount>
        {
            new Discount{Id = 1, Description ="Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent", PercentDiscount = 10, CreatedDate = DateTime.Now}
        };


        private readonly IMapper _mapper;
        public DiscountService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<ServiceResponse<List<GetDiscountDto>>> Add(AddDiscountDto newBenefit)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetDiscountDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetDiscountDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetDiscountDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetDiscountDto>> Update(UpdateDiscountDto updateBenefit)
        {
            throw new NotImplementedException();
        }
    }
}
