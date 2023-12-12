using DataEntities.Entities;

namespace DataEntities.Repositories
{
    public interface IPropertyRepository 
    {
        IEnumerable<Property> GetProperties();
        IEnumerable<Property> GetAvailableProperties(DateTime start, DateTime end);
        Property AddProperty(Property property);
        Property BookProperty(int propertyId, DateTime start, DateTime end);
        PropertyImage AddPropertyImage(int propertyId, string imageUrl);
    }
}
