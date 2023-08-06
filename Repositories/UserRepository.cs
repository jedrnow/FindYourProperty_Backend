using Microsoft.AspNetCore.Identity;
using PropertyScraper.Data;

namespace PropertyScraper.Repositories
{
    public class UserRepository
    {
        private readonly PropertyScraperDbContext _dbContext;

        public UserRepository(PropertyScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}