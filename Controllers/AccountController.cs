using Carbon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Carbon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/AccountController
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _accountService.Get());
        }               
    }
}
