using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotDefterim.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotDefterim.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UyelerController : Controller
    {
        private readonly ApplicationDbContext db;

        public UyelerController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpPost]
        public IActionResult DurumGuncelle(string kullaniciId, bool aktifMi)
        {
            ApplicationUser user = db.Users.Find(kullaniciId);

            if (user == null)
                return NotFound();

            user.LockoutEnabled = true;
            user.LockoutEnd = aktifMi ? null : DateTimeOffset.MaxValue;
            db.SaveChanges();

            return Ok();
        }
    }
}
