using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
