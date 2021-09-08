using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotDefterim.Data;
using NotDefterim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotDefterim.Controllers
{
    [Authorize]
    public class NotlarController : Controller
    {
        private readonly ApplicationDbContext db;

        public NotlarController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(NewNoteViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Note note = new Note()
                {
                    Title = vm.Title,
                    Content = vm.Content,
                    AuthorId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sil(int id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Note note = db.Notes.Where(x => x.Id == id && x.AuthorId == userId).FirstOrDefault();

            if (note == null)
                return NotFound();

            db.Remove(note);
            db.SaveChanges();

            return Ok();
        }
    }
}
