namespace PropertyScraper.Models
{
    public class PropertyItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public PropertyImage? MainImage { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Url { get; set; }
        public int Price { get; set; }
        public int PricePerMeter { get; set; }
        public string? Surface { get; set; }
        public string? NumberOfRooms { get; set; }
        public string? Rent { get; set; }
        public string? Heating { get; set; }
    }
}
