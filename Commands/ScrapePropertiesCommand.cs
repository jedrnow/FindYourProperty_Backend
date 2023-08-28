using FluentValidation;
using MediatR;

namespace PropertyScraper.Commands
{
    public record ScrapePropertiesCommand : IRequest<bool>
    {
        public string Url { get; set; }
        public string City { get; set; }
        public bool FullScrap { get; set; }
    }

    public class ScrapePropertiesCommandValidator : AbstractValidator<ScrapePropertiesCommand>
    {
        public ScrapePropertiesCommandValidator()
        {
            // TO DO: validation
        }
    }
}
