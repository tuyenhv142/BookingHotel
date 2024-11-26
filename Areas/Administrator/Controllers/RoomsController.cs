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
    public class RoomsController : Controller
    {
        private readonly BHContext _context;
        public RoomsController(BHContext context)
        {
            _context = context;
        }

        [Route("roomAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            try
            {
                var pageNumber = (page <= 0) ? 1 : page;
                var pageSize = 5;
                var lsRoom = _context.Rooms.Include(x=>x.Hotel).OrderByDescending(x => x.RoomTimeCreate);
                PagedList<Room> room = new PagedList<Room>(lsRoom, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                ViewData["LoaiKhachSan"] = new SelectList(_context.Hotels, "HotelId", "HotelName");
                return View(room);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            ViewData["LoaiKhachSan"] = new SelectList(_context.Hotels, "HotelId", "HotelName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(room);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException e)
                {
                    ModelState.AddModelError("", "Thêm mới thất bại" + e.Message);
                }
            }

            return View(room);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["LoaiKhachSan"] = new SelectList(_context.Hotels, "HotelId", "HotelName");
            Room room=_context.Rooms.Find(id);
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Rooms.Update(room);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại" + ex.Message);
                }

            }
            return View(room);
        }
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            _context.Rooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
