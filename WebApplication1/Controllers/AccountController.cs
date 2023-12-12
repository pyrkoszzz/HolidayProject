using DataEntities.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBookingRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
            IBookingRepository repository, UserManager<IdentityUser> manager)
        {
            _repository = repository;
            _userManager = manager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.Users.FirstOrDefault()?.Id;
            var bookings = _repository.GetBookingsByUser(userId);

            return View(bookings);
        }
    }
}
