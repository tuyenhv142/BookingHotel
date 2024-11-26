using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly BHContext _context;
        public HomeController(BHContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var booking = _context.Bookings.Include(x => x.Room).ThenInclude(x => x.Hotel)
                .Include(x => x.Status).Where(x => x.BookingTimeCreate == DateTime.Now.Date && x.StatusId == 1).ToList();
            List<Booking> bookings = booking.ToList();
            var news = _context.SupportOnlines.ToList();
            ViewBag.news = news;
            var coutBooking = _context.Bookings.Count();
            ViewBag.coutBooking = coutBooking;
            var sumBookingMoney = _context.Bookings.Sum(x => x.BookingTotalMoney);
            ViewBag.sumBookingMoney = sumBookingMoney;
            var SumBookingContact = _context.Bookings.Where(x=>x.StatusId == 1).Count();
            ViewBag.SumBookingContact = SumBookingContact;
            return View(bookings);
        }

    }
}
