using MediatR;
using Microsoft.IdentityModel.Tokens;
using PropertyScraper.Commands;
using PropertyScraper.Data;
using PropertyScraper.Models;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace PropertyScraper.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly PropertyScraperDbContext _dbContext;

        public LoginUserCommandHandler(PropertyScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string>Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

            await ValidateUserCredentials(user, request.Email, request.Password);

            string token = GenerateJWTToken(request.Email, user.Username);

            return token;
        }

        private async Task ValidateUserCredentials(User user,string email, string password)
        {
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new InvalidCredentialException("Wrong password");
            }
        }

        private string GenerateJWTToken(string email, string username)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(new string('z', 150)); // Replace with your own secret key

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(
                                new Claim[]
                                    {
                                        new Claim(ClaimTypes.Name, username),
                                        new Claim(ClaimTypes.Email, email)
                                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}
