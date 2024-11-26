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
    public class AccountsController : Controller
    {
        private readonly BHContext _context;
        public AccountsController(BHContext context)
        {
            _context = context;
        }
        [Route("accountAdmin.html")]
        public IActionResult Index(int page = 1)
        {
            var pageNumber = ( page <= 0) ? 1 : page;
            var pageSize = 8;
            var lsAccount = _context.Accounts.Include(x => x.Position).ToList();
            PagedList<Account> account = new PagedList<Account>(lsAccount, pageNumber, pageSize);
            ViewBag.pageCurrent = pageNumber;
            return View(account);        }
        public IActionResult Create()
        {
            ViewBag.Position = new SelectList(_context.Positions, "PositionId", "PositionName");
            return View();
        }

        [HttpPost]
        public IActionResult Create( Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public IActionResult Edit(int id)
        {
            var account =  _context.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["Position"] = new SelectList(_context.Positions, "PositionId", "PositionName");
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
                catch (DbUpdateConcurrencyException)
                {
                    return View(account);
                }
            }
            return View(account);
        }

        public IActionResult Delete(int id)
        {

            var account =  _context.Accounts.Find(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
