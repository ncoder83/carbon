using Carbon.Core.Models;
using Carbon.Models;
using Carbon.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carbon.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// This method will get all the employees
        /// </summary>
        /// <returns>return a list of employee</returns>
        Task<ServiceResponse<List<GetEmployeeDto>>> GetAll();

        /// <summary>
        /// This method will get one emplooyee given the id
        /// </summary>
        /// <param name="id">employe id to get</param>
        /// <returns>return the employee found</returns>
        Task<ServiceResponse<GetEmployeeDto>> GetById(int id);

        /// <summary>
        /// This method will add a new employee
        /// </summary>
        /// <param name="newEmployee">new employee data to add</param>
        /// <returns>retur a list with the new employee added</returns>
        Task<ServiceResponse<List<GetEmployeeDto>>> Add(AddEmployeeDto newEmployee);

        /// <summary>
        /// This method will update a new employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetEmployeeDto>> Update(UpdateEmployeeDto employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<GetEmployeeDto>>> Delete(int id);

    }
}
