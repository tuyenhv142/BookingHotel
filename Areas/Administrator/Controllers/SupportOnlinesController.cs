using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingHotel.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using PagedList.Core;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class SupportOnlinesController : Controller
    {
        private readonly BHContext _context;
        public SupportOnlinesController(BHContext context)
        {
            _context = context;
        }

        [Route("contactAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            try
            {
                var pageNumber = (page <= 0) ? 1 : page;
                var pageSize = 10;
                var support = _context.SupportOnlines.AsNoTracking().OrderBy(x => x.Id);
                PagedList<SupportOnline> supportOnlines = new PagedList<SupportOnline>(support, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(supportOnlines);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Delete(int id)
        {
            var supportOnline = _context.SupportOnlines.Find(id);
            if (supportOnline == null)
            {
                return NotFound();
            }
            _context.SupportOnlines.Remove(supportOnline);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
