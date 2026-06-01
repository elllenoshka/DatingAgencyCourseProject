using DatingAgencyServer.Dtos;
using DatingAgencyServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatingAgencyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService clientService;

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterClientRequestDto request)
        {
            RegisterClientResponseDto response = clientService.RegisterClient(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}