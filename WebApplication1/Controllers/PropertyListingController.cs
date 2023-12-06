using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PropertyListingController : Controller
    {
        private static List<PropertyListingModel> properties = new()
        {
            new()
            {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350
            },
            new()
            {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730
            }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            return View();
        }

        public ActionResult ListAvailable(DateTime start, DateTime end)
        {
            // Filter properties based on availability between start and end dates
            return View("ListAll");
        }
    }
}
