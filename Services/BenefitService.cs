using AutoMapper;
using Carbon.Core.Models;
using Carbon.DataLayer.Context;
using Carbon.Models;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class BenefitService : IBenefitService
    {

        private readonly IMapper _mapper;

        private readonly CarbonDbContext _context;

        public BenefitService(IMapper mapper, CarbonDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetBenefitDto>>> Add(AddBenefitDto newBenefit)
        {
            var response = new ServiceResponse<List<GetBenefitDto>>();
            try
            {
                var converted = _mapper.Map<Benefit>(newBenefit);
                
                await _context.Benefits.AddAsync(converted);
                await _context.SaveChangesAsync();
                response.Data = _context.Benefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
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
                var benefitToDelete = await _context.Benefits.FirstAsync(e => e.Id == id);
                _context.Benefits.Remove(benefitToDelete);
                await _context.SaveChangesAsync();
                
                response.Data = _context.Benefits.Select(e => _mapper.Map<GetBenefitDto>(e)).ToList();
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
                var allBenefits = await _context.Benefits.ToListAsync(); 
                response.Data = allBenefits.Select(b => _mapper.Map<GetBenefitDto>(b)).ToList();
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
                var benefitFound = await _context.Benefits.FirstOrDefaultAsync(b => b.Id == id);

                if (benefitFound == null)
                    throw new Exception("Benefit not found");

                response.Data = _mapper.Map<GetBenefitDto>(benefitFound);
            }
            catch(Exception ex) 
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
                var updatedBenefit = await _context.Benefits.FirstOrDefaultAsync(e => e.Id == updateBenefit.Id);
                
                updatedBenefit.Title = updateBenefit.Title;
                updatedBenefit.CostPerYear = updateBenefit.CostPerYear;
                updatedBenefit.CostPerDependent = updateBenefit.CostPerDependent;
                updateBenefit.UpdatedDate = DateTime.Now;

                _context.Benefits.Update(updatedBenefit);
                await _context.SaveChangesAsync();
                
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
