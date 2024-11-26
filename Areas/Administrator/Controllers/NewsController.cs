using Microsoft.AspNetCore.Mvc;
using BookingHotel.Models;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class NewsController : Controller
    {
        private readonly BHContext _context;
        public NewsController(BHContext context)
        {
            _context = context;
        }
        [Route("newsAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            var pageNumber = (page <= 0) ? 1 : page;
            var pageSize = 6;
            var Page = _context.Pages.AsNoTracking();
            PagedList<Page> pages = new PagedList<Page>(Page,pageNumber,pageSize);
            ViewBag.pageNumber = pageNumber;
            return View(pages);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var News = _context.Pages.Find(id);
            return View(News);
        }
        [HttpPost]
        public IActionResult Create(Page page)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Add(page);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(page);
                }
            }
            return View(page);
        }
        [HttpPost]
        public IActionResult Edit(Page page)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(page);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(page);
                }
            }
            return View(page);
        }
        public IActionResult Delete(int id)
        {
            var news = _context.Pages.Find(id);
            try
            {
                _context.Pages.Remove(news);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
            }
            return View();
        }
    }
}
