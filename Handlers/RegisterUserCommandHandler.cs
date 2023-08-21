using MediatR;
using PropertyScraper.Commands;
using PropertyScraper.Data;
using PropertyScraper.Models;
using PropertyScraper.Repositories;

namespace PropertyScraper.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,bool>
    {
        private readonly PropertyScraperDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(PropertyScraperDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await CheckIfUserAlreadyExists(request.Username, request.Email);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            AddUser(request.Username,request.Email,passwordHash);

            return (await _dbContext.SaveChangesAsync() >0);
        }

        private async Task CheckIfUserAlreadyExists(string username,string email)
        {
            bool userAlreadyExists = await _userRepository.CheckUserAlreadyExists(username, email);

            if (userAlreadyExists)
            {
                throw new InvalidOperationException("Unauthorized");
            }
        }

        private void AddUser(string username,string email, string passwordHash)
        {
            User newUser = new()
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash
            };

            _dbContext.Users.Add(newUser);
        }
    }
}
