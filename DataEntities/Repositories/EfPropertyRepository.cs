using DataEntities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Properties.AsNoTracking().ToList();
        }

        public IEnumerable<Property> GetAvailable(DateTime start, DateTime end)
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
    }
}
