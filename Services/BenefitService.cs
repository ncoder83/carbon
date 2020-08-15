using AutoMapper;
using Carbon.Core.Models;
using Carbon.Models;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class BenefitService : IBenefitService
    {

        private static List<Benefit> benefits = new List<Benefit> 
        {
            new Benefit{Id = 1, Name ="Simple Benefit", CostPerDependent = 500.00m, CostPerYear = 1000.00m, CreatedDate = DateTime.Now}
        };

        private readonly IMapper _mapper;

        public BenefitService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> Add(AddBenefitDto newBenefit)
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            benefits.Add(_mapper.Map<Benefit>(newBenefit));
            response.Data = benefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            response.Data = benefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetBenefitDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetBenefitDto>();
            response.Data = _mapper.Map<GetBenefitDto>(benefits.FirstOrDefault(b => b.Id == id));
            return response;
        }

        public async Task<ServiceResponse<GetBenefitDto>> Update(UpdateBenefitDto updateBenefit)
        {
            throw new NotImplementedException();
        }
    }
}
