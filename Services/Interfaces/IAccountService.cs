using Carbon.Models;
using Carbon.Models.DTO;
using System.Threading.Tasks;

namespace Carbon.Services.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// This method will get the account
        /// </summary>
        /// <returns>return a list of employee</returns>
        Task<ServiceResponse<GetAccountDto>> Get();

    }
}
