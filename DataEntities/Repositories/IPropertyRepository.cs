using DataEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities.Repositories
{
    public interface IPropertyRepository 
    {
        IEnumerable<Property> GetProperties();
        Property AddProperty(Property property);
    }
}
