using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace BookingHotel.Controllers
{
    public class NewController : Controller
    {
        private readonly BHContext _context;
        public NewController (BHContext context)
        {
            _context = context;
        }
        [Route("tintuc.html")]
        public IActionResult Index(int page = 1)
        {
            var pageNumber = (page <= 0) ? 1 : page;
            var pageSize = 9;
            var lsNew = _context.Pages.AsNoTracking().OrderBy(x => x.Id).Where(x=>x.Status==true);
            PagedList<Page> pages = new PagedList<Page>(lsNew, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(pages);
        }
        [Route("/tin-tuc/{id}.html")]
        public IActionResult Detail(int id)
        {
            
            var newDetail =  _context.Pages.AsNoTracking().SingleOrDefault(x => x.Id == id);
            if (newDetail == null)
            {
                return NotFound();
            }
            var lsNew = _context.Pages.AsNoTracking().Where(x=>x.Id != id).Take(3).ToList();
            ViewBag.lsNew = lsNew;
            return View(newDetail);
        }
    }
}
