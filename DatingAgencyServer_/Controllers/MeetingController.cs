using DatingAgencyServer.Dtos;
using DatingAgencyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingAgencyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly MeetingService meetingService;

        public MeetingController(MeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        [HttpGet("match/{matchId}")]
        public IActionResult GetSelectedMatch(int matchId)
        {
            return Ok(meetingService.GetSelectedMatch(matchId));
        }

        [HttpGet("match/{matchId}/meetings")]
        public IActionResult GetMeetingsForMatch(int matchId)
        {
            return Ok(meetingService.GetMeetingsForMatch(matchId));
        }

        [HttpPost("create")]
        public IActionResult CreateMeeting([FromBody] CreateMeetingRequestDto request)
        {
            ApiResponseDto response = meetingService.CreateMeeting(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}