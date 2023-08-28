using Microsoft.EntityFrameworkCore;
using PropertyScraper.Data;
using PropertyScraper.Models;

namespace PropertyScraper.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyScraperDbContext _dbContext;

        public PropertyRepository(PropertyScraperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Property> GetById(int id)
        {
            return await _dbContext.Properties.FindAsync(id);
        }

        public async Task<Property> GetByHref(string href)
        {
            return await _dbContext.Properties.FirstOrDefaultAsync(p => p.Href == href);
        }

        public async Task<bool> Add(Property property)
        {
            try
            {
                await _dbContext.Properties.AddAsync(property);
                return true;
            }
            catch (OperationCanceledException ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            Property property = await _dbContext.Properties.FindAsync(id);
            if (property != null)
            {
                _dbContext.Properties.Remove(property);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IQueryable<Property>> GetAll()
        {
            return _dbContext.Properties
                .Include(p => p.PropertyImages)
                .AsNoTracking();
        }
        public async Task<IQueryable<Property>> GetAllByCity(string city)
        {
            return _dbContext.Properties
                .Where(x => x.City == city)
                .Include(p => p.PropertyImages)
                .AsNoTracking();
        }

        public async Task<bool> DeleteAllByCity(string city)
        {
            var propertiesToDelete = _dbContext.Properties.Where(x => x.City == city).Include(p => p.PropertyImages);
            _dbContext.RemoveRange(propertiesToDelete);

            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
