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
        private static List<Employee> emp = new List<Employee>
        {
            new Employee{Id = 1, FirstName ="Pascal", LastName = "Anglade",  StartDate = DateTime.Now.AddYears(-5), EndDate = DateTime.MaxValue, Account =  new Account
            {
                Id = 1,
                Amount = 52000,
                CreatedDate = DateTime.Now
            }},
            new Employee{Id = 2, FirstName ="Thierry", LastName = "Anglade", StartDate = DateTime.Now.AddYears(-3), EndDate = DateTime.MaxValue , Account =  new Account
            {
                Id = 1,
                Amount = 52000,
                CreatedDate = DateTime.Now
            }},
            new Employee{Id = 3, FirstName ="Gaston", LastName = "Anglade" , StartDate = DateTime.Now.AddYears(-1), EndDate = DateTime.MaxValue , Account =  new Account
            {
                Id = 1,
                Amount = 52000,
                CreatedDate = DateTime.Now
            }},
            new Employee{Id = 4, FirstName ="Suhans", LastName = "Anglade" , StartDate = DateTime.Now.AddYears(-2), EndDate = DateTime.MaxValue, Account =  new Account
            {
                Id = 1,
                Amount = 52000,
                CreatedDate = DateTime.Now
            }},
        };


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
            var dbEmployees = await _context.Employees.ToListAsync();

            response.Data =  emp.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
            //response.Data = dbEmployees.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();

            return response;
        }


        public async Task<ServiceResponse<GetEmployeeDto>> GetById(int id)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            var item = _mapper.Map<GetEmployeeDto>(emp.FirstOrDefault(e => e.Id == id));

            if (item == null)
                response.Success = false;
            else
                response.Data = item;

            return response;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newEmployee)
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            var converted = _mapper.Map<Employee>(newEmployee);

            var account = new Account
            {
                Id = 1,
                Amount = Calculator.TotalPaidYearly(26, 2000),
                CreatedDate = DateTime.Now
            };

            converted.Account = account;

            

            converted.Id = emp.Max(e => e.Id) + 1;
            emp.Add(converted);
            response.Data = emp.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetEmployeeDto>> Update(UpdateEmployeeDto employee)
        {
            var response = new ServiceResponse<GetEmployeeDto>();
            try
            {
                var updatedEmployee = emp.FirstOrDefault(e => e.Id == employee.Id);
                updatedEmployee.FirstName = employee.FirstName;
                updatedEmployee.MiddleName = employee.MiddleName;
                updatedEmployee.LastName = employee.LastName;
                updatedEmployee.Username = employee.Username;
                updatedEmployee.Password = employee.Password;

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
                var employee = emp.First(e => e.Id == id);
                emp.Remove(employee);

                response.Data = emp.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
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
