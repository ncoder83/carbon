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
            new Benefit{Id = 1, Title ="Simple Benefit", CostPerDependent = 500.00m, CostPerYear = 1000.00m, CreatedDate = DateTime.Now}
        };

        private readonly IMapper _mapper;

        public BenefitService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> Add(AddBenefitDto newBenefit)
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            try
            {
                var converted = _mapper.Map<Benefit>(newBenefit);
                converted.Id = benefits.Max(b => b.Id) + 1;
                benefits.Add(converted);

                response.Data = benefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            try
            {
                var employee = benefits.First(e => e.Id == id);
                benefits.Remove(employee);

                response.Data = benefits.Select(e => _mapper.Map<GetBenefitDto>(e)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            try
            {
                response.Data = benefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
            }
            catch(Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetBenefitDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetBenefitDto>();
            try
            {
                var benefitFound = _mapper.Map<GetBenefitDto>(benefits.FirstOrDefault(b => b.Id == id));

                if (benefitFound == null)
                    throw new Exception("Benefit not found");

                response.Data = benefitFound;
            }catch(Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }
           
            return response;
        }

        public async Task<ServiceResponse<GetBenefitDto>> Update(UpdateBenefitDto updateBenefit)
        {
            var response = new ServiceResponse<GetBenefitDto>();
            try
            {
                var updatedBenefit = benefits.FirstOrDefault(e => e.Id == updateBenefit.Id);
                updatedBenefit.Title = updateBenefit.Title;
                updatedBenefit.CostPerYear = updateBenefit.CostPerYear;
                updatedBenefit.CostPerDependent = updateBenefit.CostPerDependent;
                updateBenefit.UpdatedDate = DateTime.Now;
                
                response.Data = _mapper.Map<GetBenefitDto>(updatedBenefit);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
