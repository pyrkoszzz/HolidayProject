using DataEntities.Entities;

namespace DataEntities.Repositories
{
    public class DummyPropertyRepository : IPropertyRepository
    {
        private List<Property> properties = new()
        {
            new()
            {
                PropertyId = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "A beautifully converted 1945 boat nestled within a private forest overlooking the beautiful open fenland countryside. Perfect retreat for couples looking to relax, explore and visit the local towns. Located 15 minutes drive from Ely and 30 minutes from Cambridge.",
                //Amenities = new List<string> { "Garden view", "Wifi", "Dedicated workspace" },
                BookedNights = new List<BookedNight> { new BookedNight() }
            },
            new()
            {
                PropertyId = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "We welcome you to come and stay in one of our newly renovated Airbnb rooms set within our beautiful converted barn in the Whicham Valley. A peaceful, picturesque location with rural open views of the Combes. With Silecroft beach just a 5 minute drive away and Black Combe Fell (one of the Lake District's famous Wainwright's) walking distance from the barn.",
                //Amenities = new List<string> { "Hair dryer", "Wifi", "Backyard" },
                BookedNights = new List<BookedNight> { new BookedNight() }
            }
        };

        public IEnumerable<Property> GetProperties()
        {
            return properties;
        }

        public Property AddProperty(Property property)
        {
            property.PropertyId = properties.Any() ? properties.Max(p => p.PropertyId) + 1 : 1;
            properties.Add(property);
            return property;
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Property BookProperty(int propertyId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public PropertyImage AddPropertyImage(int propertyId, string imageUrl)
        {
            throw new NotImplementedException();
        }
    }
}
