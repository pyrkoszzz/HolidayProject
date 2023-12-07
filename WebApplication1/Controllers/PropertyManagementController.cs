using AutoMapper;
using DataEntities;
using DataEntities.Entities;
using DataEntities.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyManagementController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public IActionResult RegisterProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterProperty(PropertyDetailsModel propertyDetailsModel)
        {
            if (propertyDetailsModel == null)
                return NotFound();
            
            var mapped_property = _mapper.Map<Property>(propertyDetailsModel);

            _propertyRepository.AddProperty(mapped_property);
            return Ok(mapped_property);
        }
    }
}
