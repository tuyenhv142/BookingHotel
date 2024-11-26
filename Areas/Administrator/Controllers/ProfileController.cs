
using BookingHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class ProfileController : Controller
    {
        private readonly BHContext _context;
        public ProfileController(BHContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            int accountId = (int)HttpContext.Session.GetInt32("AccountId");
            var account = _context.Accounts.Include(x => x.Position).FirstOrDefault(x => x.AccountId == accountId);
            ViewData["ChucVu"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            return View(account);
        }
        public IActionResult Edit(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Accounts.Update(account);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
            return View(account);
        }
        public IActionResult ChangePassword(int id)
        {
            var account = _context.Accounts.Find(id);
            return View(account);
        }
        [HttpPost]
        public IActionResult ChangePassword(int accountId, string currentPassword, string newPassword, string renewPassword)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);

            if (account == null)
            {
                TempData["ChangePassword"] = "Lỗi đổi mật khẩu";
                return RedirectToAction("Index", new { id = accountId });
            }

            if (account.AccountPassword!= currentPassword)
            {
                TempData["ChangePassword"] = "Mật khẩu hiện tại không chính xác";
                return RedirectToAction("Index", new { id = accountId });
            }
            if(newPassword != renewPassword)
            {
                TempData["ChangePassword"] = "Mật khẩu nhập lại không chính xác";
                return RedirectToAction("Index", new { id = accountId });
            }

            account.AccountPassword = newPassword;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
