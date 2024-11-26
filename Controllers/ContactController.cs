using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    public class ContactController : Controller
    {
        private readonly BHContext _context;
        public ContactController(BHContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SupportOnline supportOnline)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(supportOnline);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Home", "Index");
                }
            }
            return View(supportOnline);
        }
    }
}
