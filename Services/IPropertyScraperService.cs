using PropertyScraper.Models;

namespace PropertyScraper.Services
{
    public interface IPropertyScraperService
    {
        Task<bool> ScrapAndSaveProperties(string url, string city, bool triggerFullScrap);

        Task<List<string>> ScrapAllAds(string url);

        Task<bool> ScrapRangeByHref(List<string> hrefAttributes, string city, bool triggerFullScrap);

        Task<Property> SortParameters(Property property, Dictionary<string, string> parameters);

        Task<List<PropertyItemDto>> GetPropertiesByCity(string city);

        Task<bool> SaveChangesAsync();
    }
}
