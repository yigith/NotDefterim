using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotDefterim.Data;
using NotDefterim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NotDefterim.ViewComponents
{
    // https://docs.microsoft.com/tr-tr/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0
    public class ProfilResmiViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilResmiViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int genislik, int yukseklik, string sinif)
        {
            var userId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var vm = new ProfilResmiComponentViewModel()
            {
                DosyaAd = user.Photo,
                Genislik = genislik,
                Yukseklik = yukseklik,
                Sinif = sinif
            };
            return View(vm);
        }
    }
}
