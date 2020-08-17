using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carbon.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carbon.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        // GET: api/<DiscountsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("good to go");
        }

        // GET api/<DiscountsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<DiscountsController>
        [HttpPost]
        public void Post([FromBody] AddDiscountDto value)
        {
        }

        // PUT api/<DiscountsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UpdateDiscountDto value)
        {
        }

        // DELETE api/<DiscountsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
