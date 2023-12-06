namespace WebApp.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public string Description { get; set; }
        public List<string> Amenities { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}
