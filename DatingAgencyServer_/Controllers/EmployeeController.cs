using DatingAgencyServer.Dtos;
using DatingAgencyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingAgencyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("clients")]
        public IActionResult GetClients()
        {
            return Ok(employeeService.GetClients());
        }

        [HttpGet("matches")]
        public IActionResult GetMatches()
        {
            return Ok(employeeService.GetMatches());
        }

        [HttpGet("meetings")]
        public IActionResult GetMeetings()
        {
            return Ok(employeeService.GetMeetings());
        }

        [HttpPost("matches/create")]
        public IActionResult CreateMatch([FromBody] CreateMatchRequestDto request)
        {
            CreateMatchResponseDto response = employeeService.CreateMatch(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}