using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Controllers
{
    public class BookingController : Controller
    {
        private readonly BHContext _context;
        public BookingController(BHContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Booking(Booking booking)
        {
            try
            {
                _context.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Success", new { id = booking.BookingId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Home", "Index");
            }
        }
        public IActionResult Success(int id)
        {
            var booking = _context.Bookings.AsNoTracking().Include(x=>x.Payment).Include(x=>x.Room).SingleOrDefault(x=>x.BookingId == id);
            if(booking != null)
            {
                var room = _context.Rooms.AsNoTracking().Include(x => x.Hotel).SingleOrDefault(x => x.RoomId == booking.RoomId);
                ViewBag.Room = room;
            }
            return View(booking);
        }
    }
}
