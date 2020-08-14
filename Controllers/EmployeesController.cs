using System.Collections.Generic;
using System.Threading.Tasks;
using Carbon.Core.Models;
using Carbon.Models.DTO;
using Carbon.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carbon.Site.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            return Ok(await _employeeService.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto newEmployee)
        {
            return Ok(await _employeeService.Add(newEmployee));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto newEmployee)
        {
            var response = await _employeeService.Update(newEmployee);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await _employeeService.Delete(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
