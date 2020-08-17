using Carbon.Models;
using Carbon.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carbon.Services.Interfaces
{
    interface IDiscountService
    {
        /// <summary>
        /// This method will get all the benefits
        /// </summary>
        /// <returns>return a list of employee</returns>
        Task<ServiceResponse<List<GetDiscountDto>>> GetAll();

        /// <summary>
        /// This method will get one benefit given the id
        /// </summary>
        /// <param name="id">employe id to get</param>
        /// <returns>return the employee found</returns>
        Task<ServiceResponse<GetDiscountDto>> GetById(int id);

        /// <summary>
        /// This method will add a new employee
        /// </summary>
        /// <param name="newEmployee">new employee data to add</param>
        /// <returns>retur a list with the new employee added</returns>
        Task<ServiceResponse<List<GetDiscountDto>>> Add(AddDiscountDto newBenefit);

        /// <summary>
        /// This method will update the benefit information
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetDiscountDto>> Update(UpdateDiscountDto updateBenefit);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<GetDiscountDto>>> Delete(int id);
    }
}
