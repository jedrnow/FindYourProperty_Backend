using MediatR;
using PropertyScraper.Models;
using PropertyScraper.Queries;
using PropertyScraper.Services;

namespace PropertyScraper.Handlers
{
    public class GetPropertiesByCityQueryHandler : IRequestHandler<GetPropertiesByCityQuery, List<PropertyItemDto>>
    {
        private readonly IPropertyScraperService _propertyScraperService;
        public GetPropertiesByCityQueryHandler(IPropertyScraperService propertyScraperService)
        {
            _propertyScraperService = propertyScraperService;
        }

        public async Task<List<PropertyItemDto>> Handle(GetPropertiesByCityQuery request, CancellationToken cancellationToken)
        {
            List<PropertyItemDto> propertiesByCity = await _propertyScraperService.GetPropertiesByCity(request.City);

            return propertiesByCity;
        }
    }
}
