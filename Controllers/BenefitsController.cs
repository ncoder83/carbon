using System.Threading.Tasks;
using Carbon.Models.DTO;
using Carbon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Carbon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitService _benefitService;

        public BenefitsController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _benefitService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _benefitService.GetById(id);

            if (response.Data == null)
                return NotFound(response);
           
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddBenefit(AddBenefitDto newBenefit)
        {
            return Ok(await _benefitService.Add(newBenefit));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBenefit(UpdateBenefitDto updatedBenefit)
        {
            var response = await _benefitService.Update(updatedBenefit);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await _benefitService.Delete(id);

            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
