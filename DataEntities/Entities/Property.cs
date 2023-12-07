namespace DataEntities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public string Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public float CostPerNight { get; set; }
        public string Description { get; set; }
        public List<string> Amenities { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}