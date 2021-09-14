using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotDefterim.Data;
using NotDefterim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// https://docs.microsoft.com/tr-tr/aspnet/core/mvc/models/file-uploads?view=aspnetcore-5.0
namespace NotDefterim.Controllers
{
    [Authorize]
    public class ProfilResmiController : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly ApplicationDbContext db;

        public ProfilResmiController(IWebHostEnvironment env, ApplicationDbContext db)
        {
            this.env = env;
            this.db = db;
        }

        public IActionResult Index(string sonuc)
        {
            var vm = new ProfilResmiViewModel()
            {
                Yuklendi = sonuc == "yuklendi",
                Foto = db.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)).Photo
            };
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
                ModelState.AddModelError("photo", "Yüklenecek bir resim dosyası bulunamadı.");

            else if (!photo.ContentType.StartsWith("image/"))
                ModelState.AddModelError("photo", "Hatalı formatta bir resim dosyası seçtiniz.");

            // izin verilen en büyük dosya boyutu 1MB
            else if (photo.Length > 1 * 1000 * 1000)
                ModelState.AddModelError("photo", "Maksimum dosya boyutu 1MB'dır.");


            if (ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(photo.FileName);
                string yeniDosyaAd = Guid.NewGuid() + uzanti;
                string kayitYolu = Path.Combine(env.WebRootPath, "uploads", yeniDosyaAd);
                using (FileStream fs = System.IO.File.Create(kayitYolu))
                {
                    photo.CopyTo(fs);
                }
                ApplicationUser user = db.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier));
                user.Photo = yeniDosyaAd;
                db.SaveChanges();
                return RedirectToAction("Index", new { sonuc = "yuklendi" });
            }
            var vm = new ProfilResmiViewModel()
            {
                Foto = db.Users.Find(User.FindFirstValue(ClaimTypes.NameIdentifier)).Photo
            };
            return View(vm);
        }
    }
}
