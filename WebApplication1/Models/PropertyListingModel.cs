namespace WebApp.Models
{
    public class PropertyListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public string Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public float CostPerNight { get; set; }
        public IEnumerable<string> Images { get; set; } = new List<string>();
    }
}
