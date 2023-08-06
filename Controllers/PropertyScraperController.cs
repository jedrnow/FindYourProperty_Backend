using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyScraper.Commands;
using PropertyScraper.Models;
using PropertyScraper.Queries;
using PropertyScraper.Services;

namespace PropertyScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyScraperController : ControllerBase
    {
        private readonly PropertyScraperService _scraperService;

        public PropertyScraperController(PropertyScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        [HttpPost("Scrap")]
        public async Task<ActionResult<bool>> ScrapeProperties([FromBody] ScrapePropertiesCommand command)
        {
            bool scrapingCompleted = await _scraperService.ScrapAndSaveProperties(command.Url, command.City, command.FullScrap);

            return Ok(scrapingCompleted);
        }

        [HttpGet("GetAllByCity")]
        public async Task<ActionResult<List<PropertyItemDto>>> GetPropertiesByCity([FromQuery]string city)
        {
            List<PropertyItemDto> result = await _scraperService.GetPropertiesByCity(city);

            return Ok(result);
        }

    }
}
