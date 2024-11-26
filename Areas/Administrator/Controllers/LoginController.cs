
using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class LoginController : Controller
    {
        private readonly BHContext _context;
        public LoginController (BHContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var login = _context.Accounts.FirstOrDefault(x => x.AccountEmail == email && x.AccountPassword == password);
                if (login != null)
                {
                    HttpContext.Session.SetInt32("AccountId", login.AccountId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginFailed"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.";
                }
            }
            return View();
        }
    }
}
