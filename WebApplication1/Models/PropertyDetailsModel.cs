namespace WebApp.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public string Description { get; set; }
        public List<string> Amenities { get; set; }
        public List<DateTime> BookedStartDates { get; set; } = new();
        public List<DateTime> BookedEndDates { get; set; } = new();
    }
}
