using AutoMapper;
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
        private readonly IWebHostEnvironment _env;

        public PropertyManagementController(IPropertyRepository propertyRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _env = env;
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
            return View();
        }
        public IActionResult AddImage(int id)
        {
            var model = new ImageModel { PropertyId = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadImage(ImageModel model)
        {
            if (model.Image != null)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                var urlPath = $"/images/{fileName}";
                var filePath = Path.Combine(_env.WebRootPath, "images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }

                _propertyRepository.AddPropertyImage(model.PropertyId, urlPath);
            }

            return RedirectToAction("ViewPropertyDetails", "PropertyListing", new { id = model.PropertyId });
        }
    }
}
