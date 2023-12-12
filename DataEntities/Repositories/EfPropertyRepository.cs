using DataEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataEntities.Repositories
{
    public class EfPropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public EfPropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Property> GetProperties()
        {
            return _context.Properties
                .Include(p => p.Images)
                .Include(p => p.BookedNights)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end)
        {
            return _context.Properties.AsNoTracking()
                .Where(p => p.BookedNights
                    .Select(n => n.Night)
                    .All(d => d <= start || d > end))
                .ToList();
        }

        public Property AddProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public PropertyImage AddPropertyImage(int propertyId, string imageUrl)
        {
            var property = _context.Properties
                .First(p => p.PropertyId == propertyId);

            var propertyImage = new PropertyImage
            {
                Property = property,
                ImageUrl = imageUrl
            };

            property.Images.Add(propertyImage);
            _context.SaveChanges();
            return propertyImage;
        }

        public Property BookProperty(int propertyId, DateTime start, DateTime end)
        {
            var property = _context.Properties
                .Include(p => p.BookedNights)
                .First(p => p.PropertyId == propertyId);

            for (var date = start.AddDays(1); date <= end; date = date.AddDays(1))
            {
                var bookedNight = new BookedNight
                {
                    Night = date
                };
                property.BookedNights.Add(bookedNight);
            }
            _context.SaveChanges();
            return property;
        }
    }
}
