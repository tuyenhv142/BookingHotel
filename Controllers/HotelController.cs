using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace BookingHotel.Controllers
{
    public class HotelController : Controller
    {
        private readonly BHContext _context;
        public HotelController(BHContext context)
        {
            _context = context;
        }
        [Route("hotel.html")]
        public IActionResult Index(int page = 1)
        {
            var pageNumber = (page <= 0) ? 1 : page;
            var pageSize = 6;
            var lsHotel = _context.Hotels.AsNoTracking().OrderBy(x => x.HotelId);
            PagedList<Hotel> hotels = new PagedList<Hotel>(lsHotel, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(hotels);
        }
        [Route("/khach-san/{id}.html")]
        public IActionResult Detail(int id)
        {
            var hotel = _context.Hotels.AsNoTracking().SingleOrDefault(x => x.HotelId == id);
            if (hotel == null)
            {
                return RedirectToAction("Index");
            }

            var lsRoom = _context.Rooms.AsNoTracking().Where(x => x.HotelId == id && x.RoomStatus == true).ToList();
            ViewBag.lsRoom = lsRoom;

            var lshotel = _context.Hotels.Where(x => x.HotelId != id).Take(3).ToList();
            ViewBag.lshotel= lshotel;

            return View(hotel);
        }

        [Route("/dat-phong/phong-{id}.html")]
        public IActionResult Booking(int id)
        {
            var room = _context.Rooms.AsNoTracking().Include(x => x.Hotel).Include(x => x.Bookings).SingleOrDefault(x => x.RoomId == id);
            ViewBag.Room = room;
            ViewData["KieuThanhToan"] = new SelectList(_context.Payments, "PaymentId", "PaymentType");
            return View();
        }

    }

}
