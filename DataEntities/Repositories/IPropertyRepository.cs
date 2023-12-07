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
        void AddProperty(Property property);
    }
}
