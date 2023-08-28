using PropertyScraper.Models;

namespace PropertyScraper.Repositories
{
    public interface IPropertyRepository
    {
        Task<Property> GetById(int id);

        Task<Property> GetByHref(string href);

        Task<bool> Add(Property property);

        Task<bool> Delete(int id);

        Task<IQueryable<Property>> GetAll();

        Task<IQueryable<Property>> GetAllByCity(string city);

        Task<bool> DeleteAllByCity(string city);

        Task<int> SaveChangesAsync();
    }
}
