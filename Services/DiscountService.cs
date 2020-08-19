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
    public class DiscountService : IDiscountService
    {
        private static List<Discount> discounts = new List<Discount>
        {
            new Discount{Id = 1, Description ="Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent", PercentDiscount = 10, CreatedDate = DateTime.Now}
        };

        private readonly IMapper _mapper;
        private readonly CarbonDbContext _context;
        public DiscountService(IMapper mapper, CarbonDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetDiscountDto>>> Add(AddDiscountDto newDiscount)
        {
            var response = new ServiceResponse<List<GetDiscountDto>>();
            try
            {
                await _context.Discounts.AddAsync(_mapper.Map<Discount>(newDiscount));
                await _context.SaveChangesAsync();
                response.Data = _context.Discounts.Select(d => _mapper.Map<GetDiscountDto>(d)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetDiscountDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetDiscountDto>>();
            try
            {
                var discountToDelete = await _context.Discounts.FirstAsync(d => d.Id == id);
                _context.Discounts.Remove(discountToDelete);
                await _context.SaveChangesAsync();

                response.Data = _context.Discounts.Select(d => _mapper.Map<GetDiscountDto>(d)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;                
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetDiscountDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetDiscountDto>>();
            try
            {
                var allDiscounts = await _context.Discounts.ToListAsync();
                response.Data = allDiscounts.Select(d => _mapper.Map<GetDiscountDto>(d)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetDiscountDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetDiscountDto>();

            try
            {
                var discountFound = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);

                if (discountFound == null)
                    throw new Exception("Discount information not found");

                response.Data = _mapper.Map<GetDiscountDto>(discountFound);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;                
            }

            return response;
        }

        public async Task<ServiceResponse<GetDiscountDto>> Update(UpdateDiscountDto updateBenefit)
        {
            var response = new ServiceResponse<GetDiscountDto>();
            try
            {

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
