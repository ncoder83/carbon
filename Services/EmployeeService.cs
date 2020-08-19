using AutoMapper;
using Carbon.Business;
using Carbon.Core.Models;
using Carbon.DataLayer.Context;
using Carbon.Models;
using Carbon.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class EmployeeService : IEmployeeService
    {

        //Local store for now
        //private static List<Employee> emp = new List<Employee>
        //{
        //    new Employee{Id = 1, FirstName ="Pascal", LastName = "Anglade",  StartDate = DateTime.Now.AddYears(-5), EndDate = DateTime.MaxValue, Account =  new Account
        //    {
        //        Id = 1,
        //        Amount = 52000,
        //        CreatedDate = DateTime.Now
        //    }},
        //    new Employee{Id = 2, FirstName ="Thierry", LastName = "Anglade", StartDate = DateTime.Now.AddYears(-3), EndDate = DateTime.MaxValue , Account =  new Account
        //    {
        //        Id = 1,
        //        Amount = 52000,
        //        CreatedDate = DateTime.Now
        //    }},
        //    new Employee{Id = 3, FirstName ="Gaston", LastName = "Anglade" , StartDate = DateTime.Now.AddYears(-1), EndDate = DateTime.MaxValue , Account =  new Account
        //    {
        //        Id = 1,
        //        Amount = 52000,
        //        CreatedDate = DateTime.Now
        //    }},
        //    new Employee{Id = 4, FirstName ="Suhans", LastName = "Anglade" , StartDate = DateTime.Now.AddYears(-2), EndDate = DateTime.MaxValue, Account =  new Account
        //    {
        //        Id = 1,
        //        Amount = 52000,
        //        CreatedDate = DateTime.Now
        //    }},
        //};


        private readonly IMapper _mapper;
        private readonly CarbonDbContext _context;

        public EmployeeService(IMapper mapper, CarbonDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();

            try
            {
                var allEmployees = await _context.Employees.ToListAsync();                
                response.Data = allEmployees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<GetEmployeeDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var employeeFound = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);                

                if (employeeFound == null)
                    throw new Exception("Employee not found");

                var benefit = await _context.Benefits.FirstOrDefaultAsync(b => b.Id == employeeFound.Benefit.Id);

                var converted = _mapper.Map<GetEmployeeDto>(employeeFound);

                converted.TotalBenefitCost = Calculator.TotalFromBenefit(benefit.CostPerYear, benefit.CostPerDependent, converted.TotalDependents);

                response.Data = converted;
            }
            catch(Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newEmployee)
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                var converted = _mapper.Map<Employee>(newEmployee);

                var account = new Account
                {
                    Amount = Calculator.TotalPaidYearly(26, 2000),
                    CreatedDate = DateTime.Now
                };

                await _context.Accounts.AddAsync(account);

                converted.Account = account;

                foreach (var dependent in newEmployee.Dependents)                
                    converted.Dependents.Add(dependent);

                await _context.Employees.AddAsync(converted);
                await _context.SaveChangesAsync();

                response.Data = _context.Employees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
            }
            catch(Exception ex) 
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> Update(UpdateEmployeeDto employee)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var updatedEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

                updatedEmployee.FirstName = employee.FirstName;
                updatedEmployee.MiddleName = employee.MiddleName;
                updatedEmployee.LastName = employee.LastName;
                updatedEmployee.Username = employee.Username;
                updatedEmployee.Password = employee.Password;                
                updatedEmployee.DateOfBirth = employee.DateOfBirth;
                updatedEmployee.StartDate = employee.StartDate;
                updatedEmployee.UpdatedDate = DateTime.Now;
                updatedEmployee.Dependents = employee.Dependents;

                _context.Employees.Update(updatedEmployee);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetEmployeeDto>(updatedEmployee);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ServiceResponse<List<GetEmployeeDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            try
            {
                var employee = await _context.Employees.FirstAsync(e => e.Id == id);

                if(employee == null)
                    throw new Exception("Employee not found");

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                
                response.Data = _context.Employees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
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
