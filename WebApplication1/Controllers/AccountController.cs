using DataEntities.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBookingRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IBookingRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public IActionResult UserBookings()
        {
            var userId = _userManager.Users.FirstOrDefault()?.Id;
            var bookings = _userRepository.GetBookingsByUser(userId);

            return View(bookings);
        }
    }
}
