using Microsoft.AspNetCore.Mvc;
using PropertyScraper.Commands;
using PropertyScraper.Services;

namespace PropertyScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] CreateUserCommand command)
        {
            return Ok(await _userService.AddUser(command.Email, command.Username, command.Password));
        }
    }
}
