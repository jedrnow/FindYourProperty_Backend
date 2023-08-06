namespace PropertyScraper.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string thumbnail { get; set; }
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string __typename { get; set; }

        public Property Property { get; set; }
    }
}
