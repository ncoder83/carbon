using AutoMapper.Configuration.Annotations;
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
            var response = await _accountService.Get();

            if (response.Data == null)
                return NotFound(response);

            return Ok(await _accountService.Get());
        }               
    }
}
