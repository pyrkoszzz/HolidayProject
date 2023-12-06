using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PropertyListingController : Controller
    {
        private static List<PropertyDetailsModel> properties = new()
        {
            new()
            {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "A beautifully converted 1945 boat nestled within a private forest overlooking the beautiful open fenland countryside. Perfect retreat for couples looking to relax, explore and visit the local towns. Located 15 minutes drive from Ely and 30 minutes from Cambridge.",
                Amenities = new List<string> { "Garden view", "Wifi", "Dedicated workspace" },
                BookedDates = new List<DateTime> { new DateTime(2023, 12, 6), new DateTime(2023, 12, 7), new DateTime(2023, 12, 8) }
            },
            new()
            {
                Id = 2,
                Name = "Safron House",
                Blurb = "Stately home on the Devon moores",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "We welcome you to come and stay in one of our newly renovated Airbnb rooms set within our beautiful converted barn in the Whicham Valley. A peaceful, picturesque location with rural open views of the Combes. With Silecroft beach just a 5 minute drive away and Black Combe Fell (one of the Lake District's famous Wainwright's) walking distance from the barn.",
                Amenities = new List<string> { "Hair dryer", "Wifi", "Backyard" },
                BookedDates = new List<DateTime> { new DateTime(2023, 12, 9), new DateTime(2023, 12, 10), new DateTime(2023, 12, 11) }
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAll()
        {
            return View("ListProperties", properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            // Filter properties based on availability between start and end dates
            var availableProperties = properties.Where(x => (!x.BookedDates.Any(date => date >= start && date <= end))).ToList();
            return View("ListProperties", availableProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            //Todo single entry only handle exeptions
            var property = properties
                .Where(x => x.Id == id);

            return View("PropertyDetails", property);
        }
    }
}
