namespace DataEntities.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int PropertyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float CostPerNight { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string BillingAddress { get; set; }
    }
}
