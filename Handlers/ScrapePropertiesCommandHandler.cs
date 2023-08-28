using MediatR;
using PropertyScraper.Commands;
using PropertyScraper.Services;

namespace PropertyScraper.Handlers
{
    public class ScrapePropertiesCommandHandler : IRequestHandler<ScrapePropertiesCommand, bool>
    {
        private readonly IPropertyScraperService _propertyScraperService;
        public ScrapePropertiesCommandHandler(IPropertyScraperService propertyScraperService)
        {
            _propertyScraperService = propertyScraperService;
        }

        public async Task<bool> Handle(ScrapePropertiesCommand request, CancellationToken cancellationToken)
        {
            bool scrapingCompleted = await _propertyScraperService.ScrapAndSaveProperties(request.Url, request.City, request.FullScrap);

            return (await _propertyScraperService.SaveChangesAsync() && scrapingCompleted);
        }
    }
}
