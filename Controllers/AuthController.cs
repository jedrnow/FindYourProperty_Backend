using Microsoft.AspNetCore.Mvc;
using PropertyScraper.Commands;
using MediatR;

namespace PropertyScraper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterUserCommand request)
        {
            bool result = await _mediator.Send(request);

            return Ok(result);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand request)
        {
            string result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
