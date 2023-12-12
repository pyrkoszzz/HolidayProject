namespace DataEntities.Entities
{
    public class BookedNight
    {
        public int BookedNightId { get; set; }
        public Property Property { get; set; }
        public DateTime Night { get; set; }
    }
}
