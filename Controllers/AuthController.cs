using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PropertyScraper.Data;
using PropertyScraper.Models;

namespace PropertyScraper.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly PropertyScraperDbContext _dbContext;

        public AuthController(PropertyScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            // Check if the username or email is already taken
            if (await _dbContext.Users.AnyAsync(u => u.Username == model.Username) || await _dbContext.Users.AnyAsync(u => u.Email == model.Email))
            {
                return BadRequest("Username or email already taken");
            }

            // Hash the password for security
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = passwordHash
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok("Registration successful");
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == model.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials");
            }

            // Authentication successful, generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(new string('z',150)); // Replace with your own secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
