using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel.Models;
using PagedList.Core;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BookingsController : Controller
    {
        private readonly BHContext _context;
        public BookingsController(BHContext context)
        {
            _context = context;
        }
        [Route("bookingAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            var pageNumber = (page <= 0) ? 1 : page;
            var pageSize = 7;
            var lsBooking = _context.Bookings.Include(x => x.Status).Include(x => x.Room).ThenInclude(x=>x.Hotel).Include(x => x.Payment).OrderByDescending(x => x.BookingTimeCreate);
            PagedList<Booking> booking = new PagedList<Booking>(lsBooking,pageNumber,pageSize);
            ViewBag.CurrentPage = pageNumber;
            
            return View(booking);
        }

        public IActionResult Create()
        {
            ViewData["ThanhToan"] = new SelectList(_context.Payments, "PaymentId", "PaymentType");
            ViewData["KhachSan"] = new SelectList(_context.Hotels, "HotelId", "HotelName");
            ViewData["Phong"] = new SelectList(_context.Rooms, "RoomId", "RoomName");
            ViewData["TrangThai"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            return View();
        }

        [HttpPost]
        public IActionResult Create( Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);

        }
        public IActionResult Edit(int id)
        {
            var idbk = id;
            var booking =  _context.Bookings.Find(id);
            var bk = _context.Bookings.AsNoTracking().Include(x => x.Room).ThenInclude(x => x.Hotel).FirstOrDefault(x => x.BookingId == idbk);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ThanhToan"] = new SelectList(_context.Payments, "PaymentId", "PaymentType");
            ViewData["Phong"] = new SelectList(_context.Rooms.Where(x => x.HotelId == bk.Room.HotelId ), "RoomId", "RoomName");
            ViewData["TrangThai"] = new SelectList(_context.Statuses, "StatusId", "StatusName");
            return View(booking);
        }

        [HttpPost]
        public IActionResult Edit( Booking booking)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Home","Index");
                }
            }
            return View(booking);
        }

        public IActionResult Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            _context.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
