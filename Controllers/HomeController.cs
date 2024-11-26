using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BookingHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly BHContext _context;
        public HomeController(BHContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lsHotel = _context.Hotels.AsNoTracking().Where(x => x.HotelFlag == true).OrderByDescending(x=>x.HotelTimeCreate).Take(3).ToList();
            ViewBag.lsHotel = lsHotel;
            var lsNews = _context.Pages.AsNoTracking().Where(x=>x.HomeFlag == true).OrderByDescending(x=>x.Time).Take(3).ToList();
            ViewBag.news = lsNews;
            return View();
        }
        public IActionResult Search(string search)
        {
            var lsHotel = _context.Hotels.AsNoTracking().Where(x => x.HotelName.Contains(search));
            ViewBag.lsHotel = search;
            return View(lsHotel);
        }

    }
}