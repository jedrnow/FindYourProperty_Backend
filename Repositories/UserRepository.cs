using PropertyScraper.Data;

namespace PropertyScraper.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PropertyScraperDbContext _dbContext;

        public UserRepository(PropertyScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckUserAlreadyExists(string username, string email)
        {
            return (_dbContext.Users.Any(u => u.Username == username) || _dbContext.Users.Any(u => u.Email == email));
        }
    }
}