using DataEntities.Entities;

namespace DataEntities.Repositories
{
    public interface IBookingRepository
    {
        public Booking MakeBooking(Booking booking);
        public IEnumerable<Booking> GetBookingsByUser(string userId);
    }
}
