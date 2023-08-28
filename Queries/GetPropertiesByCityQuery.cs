using FluentValidation;
using MediatR;
using PropertyScraper.Models;

namespace PropertyScraper.Queries
{
    public record GetPropertiesByCityQuery : IRequest<List<PropertyItemDto>>
    {
        public string City { get; set; }

        public GetPropertiesByCityQuery(string city)
        {
            City = city;
        }
    }

    public class GetPropertiesByCityQueryValidator : AbstractValidator<GetPropertiesByCityQuery>
    {
        public GetPropertiesByCityQueryValidator()
        {
            // TO DO: validation
        }
    }
}
