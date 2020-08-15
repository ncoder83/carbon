using AutoMapper;
using Carbon.Core.Models;
using Carbon.Models;
using Carbon.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> emp = new List<Employee>
        {
            new Employee{Id = 1, FirstName ="Pascal", LastName = "Anglade"  },
            new Employee{Id = 2, FirstName ="Thierry", LastName = "Anglade"  },
            new Employee{Id = 3, FirstName ="Gaston", LastName = "Anglade"  },
            new Employee{Id = 4, FirstName ="Suhans", LastName = "Anglade"  },
        };
        private readonly IMapper _mapper;

        public EmployeeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetEmployeeDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetEmployeeDto>>();
            response.Data = emp.Select(e => _mapper.Map<GetEmployeeDto>(e)).ToList();
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
            emp.Add(_mapper.Map<Employee>(newEmployee));
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
