using PropertyScraper.Repositories;
using Microsoft.AspNetCore.Identity;
using PropertyScraper.Data;

namespace PropertyScraper.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(PropertyScraperDbContext dbContext,UserManager<IdentityUser> userManager)
        {
            _userRepository = new UserRepository(dbContext);
            _userManager = userManager;
        }

        public async Task<bool>AddUser(string email,string username,string password)
        {
            IdentityUser newUser = new()
            {
                Email = email,
                UserName = username
            };
            var result = await _userManager.CreateAsync(newUser, password);

            return result.Succeeded;
        }
    }
}
