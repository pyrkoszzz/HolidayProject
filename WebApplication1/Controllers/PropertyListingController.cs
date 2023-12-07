using AutoMapper;
using DataEntities.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _properties;
        private readonly IMapper _mapper;
        public PropertyListingController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _properties = propertyRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAll()
        {
            var properties = _properties.GetProperties();
            var mapped_properties = _mapper.Map<IEnumerable<PropertyDetailsModel>>(properties);
            return View("ListProperties", mapped_properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            // Filter properties based on availability between start and end dates
            var properties = _properties.GetProperties();
            var availableProperties = properties.Where(x => (!x.BookedNights.Any(date => date.Night >= start && date.Night <= end))).ToList();
            var mapped_properties = _mapper.Map<IEnumerable<PropertyDetailsModel>>(availableProperties);
            return View("ListProperties", properties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            //Todo single entry only handle exeptions
            var properties = _properties.GetProperties();
            var property = properties
                .Where(x => x.PropertyId == id);
            var mapped_properties = _mapper.Map<IEnumerable<PropertyDetailsModel>>(property);
            return View("PropertyDetails", mapped_properties);
        }
    }
}
