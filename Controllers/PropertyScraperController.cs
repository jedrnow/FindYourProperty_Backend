using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertyScraper.Commands;
using PropertyScraper.Models;
using PropertyScraper.Queries;

namespace PropertyScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyScraperController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyScraperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Scrap")]
        public async Task<ActionResult<bool>> ScrapeProperties([FromBody] ScrapePropertiesCommand request)
        {
            bool result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("GetAllByCity")]
        public async Task<ActionResult<List<PropertyItemDto>>> GetPropertiesByCity([FromQuery]string city)
        {
            GetPropertiesByCityQuery request = new(city);

            List<PropertyItemDto> result = await _mediator.Send(request);

            return Ok(result);
        }

    }
}
