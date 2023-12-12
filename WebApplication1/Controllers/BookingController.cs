using AutoMapper;
using DataEntities.Entities;
using DataEntities.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper, UserManager<IdentityUser> manager)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _userManager = manager;
        }

        [HttpPost]
        public IActionResult BookProperty(int propertyId, DateTime start, DateTime end)
        {
            var booking = new BookingModel
            {
                PropertyId = propertyId,
                StartDate = start,
                EndDate = end
            };
            return View("CreateBooking", booking);
        }

        [HttpPost]
        public IActionResult SubmitBooking(int propertyId, DateTime startDate, DateTime endDate, string userEmail, string billingAddress)
        {
            var userId = _userManager.Users.FirstOrDefault()?.Id;


            var booking = new Booking
            {
                PropertyId = propertyId,
                StartDate = startDate,
                EndDate = endDate,
                UserId = userId,
                UserEmail = userEmail,
                BillingAddress = billingAddress
            };
            if(_bookingRepository.MakeBooking(booking) == null)
            {
                return NotFound();
            }
            return RedirectToAction("ListAll", "PropertyListing");
        }
    }
}
