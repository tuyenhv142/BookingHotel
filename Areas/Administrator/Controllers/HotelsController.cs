using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel.Models;
using System.ComponentModel.DataAnnotations;
using NuGet.ContentModel;
using PagedList.Core;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class HotelsController : Controller
    {
        private readonly BHContext _context;
        public HotelsController(BHContext context)
        {
            _context = context;
        }
        [Route("hotelAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            try
            {
                List<SelectListItem> loaiKhachSan= new List<SelectListItem>();
                loaiKhachSan.Add(new SelectListItem() { Text = "5 sao", Value = "0" });
                loaiKhachSan.Add(new SelectListItem() { Text = "4 sao", Value = "1" });
                loaiKhachSan.Add(new SelectListItem() { Text = "3 sao", Value = "2" });
                ViewData["loaiKhachSan"] = loaiKhachSan;

                var pageNumber = (page <= 0) ? 1 : page;
                var pageSize = 7;
                var lsHotel = _context.Hotels.OrderBy(x => x.HotelTimeCreate);
                PagedList<Hotel> hotels = new PagedList<Hotel>(lsHotel, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(hotels);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(hotel);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException e)
                {
                    ModelState.AddModelError("", "Thêm mới thất bại" + e.Message);
                }
            }

            return View(hotel);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Hotel hotel = _context.Hotels.Find(id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Hotels.Update(hotel);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại" + ex.Message);
                }

            }
            return View(hotel);
        }
        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }
            try
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Cập nhật thất bại" + e.Message);
                return RedirectToAction("Index");
            }
        }

    }
}
