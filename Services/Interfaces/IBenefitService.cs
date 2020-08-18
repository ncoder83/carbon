using Carbon.Models;
using Carbon.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carbon.Services.Interfaces
{
    public interface IBenefitService
    {
        /// <summary>
        /// This method will get all the benefits
        /// </summary>
        /// <returns>return a list of benefits</returns>
        Task<ServiceResponse<List<GetBenefitDto>>> GetAll();

        /// <summary>
        /// This method will get one benefit given the id
        /// </summary>
        /// <param name="id">benefit id to get</param>
        /// <returns>return the benefit found</returns>
        Task<ServiceResponse<GetBenefitDto>> GetById(int id);

        /// <summary>
        /// This method will add a new benefit
        /// </summary>
        /// <param name="newBenefit">new benefit data to add</param>
        /// <returns>return a list with the new benefit added</returns>
        Task<ServiceResponse<List<GetBenefitDto>>> Add(AddBenefitDto newBenefit);

        /// <summary>
        /// This method will update the benefit information
        /// </summary>
        /// <param name="updateBenefit"></param>
        /// <returns></returns>
        Task<ServiceResponse<GetBenefitDto>> Update(UpdateBenefitDto updateBenefit);

        /// <summary>
        /// This method will rmove the benefit given the id
        /// </summary>
        /// <param name="id">id of the benefit to delete</param>
        /// <returns>returns a list with the benefit removed removed</returns>
        Task<ServiceResponse<List<GetBenefitDto>>> Delete(int id);
    }
}
