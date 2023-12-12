using DataEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Repositories
{
    public class EfBookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public EfBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking? MakeBooking(Booking booking)
        {
            var property = _context.Properties
                .Include(p => p.BookedNights)
                .FirstOrDefault(p => p.PropertyId == booking.PropertyId);

            if (property == null || !IsPropertyAvailable(property, booking.StartDate, booking.EndDate))
                return null;

            for (var date = booking.StartDate; date <= booking.EndDate; date = date.AddDays(1))
            {
                var bookedNight = new BookedNight
                {
                    Night = date
                };
                property.BookedNights.Add(bookedNight);
            }

            booking.CostPerNight = property.CostPerNight;

            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        private static bool IsPropertyAvailable(Property property, DateTime startDate, DateTime endDate)
        {
            return property.BookedNights
                .Select(n => n.Night)
                .All(d => d <= startDate || d > endDate);
        }

        public IEnumerable<Booking> GetBookingsByUser(string? userId)
        {
            return _context.Bookings
                .Where(b => b.UserId == userId)
                .ToList();
        }
    }
}
