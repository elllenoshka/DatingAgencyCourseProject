using DatingAgencyServer.Dtos;
using DatingAgencyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingAgencyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService;

        public AdminController(AdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("clients")]
        public IActionResult GetClients()
        {
            return Ok(adminService.GetClients());
        }

        [HttpGet("matches")]
        public IActionResult GetMatches()
        {
            return Ok(adminService.GetMatches());
        }

        [HttpGet("meetings")]
        public IActionResult GetMeetings()
        {
            return Ok(adminService.GetMeetings());
        }

        [HttpGet("archive")]
        public IActionResult GetArchive()
        {
            return Ok(adminService.GetArchive());
        }

        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            return Ok(adminService.GetEmployees());
        }

        [HttpPost("employees/add")]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequestDto request)
        {
            ApiResponseDto response = adminService.AddEmployee(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("matches/create")]
        public IActionResult CreateMatch([FromBody] CreateMatchRequestDto request)
        {
            CreateMatchResponseDto response = adminService.CreateMatch(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("matches/{matchId}")]
        public IActionResult DeleteMatch(int matchId)
        {
            ApiResponseDto response = adminService.DeleteMatch(matchId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("matches/{matchId}/archive")]
        public IActionResult ArchiveMatch(int matchId)
        {
            ApiResponseDto response = adminService.ArchiveMatch(matchId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("employees/status")]
        public IActionResult SetEmployeeStatus([FromBody] ToggleEmployeeStatusRequestDto request)
        {
            ApiResponseDto response = adminService.SetEmployeeStatus(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}