using DatingAgencyServer.Dtos;
using DatingAgencyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingAgencyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("partners")]
        public IActionResult GetAllPartners()
        {
            return Ok(customerService.GetAllPartners());
        }

        [HttpPost("partners/filter")]
        public IActionResult FilterPartners([FromBody] PartnerFilterRequestDto filter)
        {
            try
            {
                return Ok(customerService.FilterPartners(filter));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponseDto
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}