using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private IUserService service;
        public LoginController(IUserService service)
        {
              this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email,string Sifre)
        {
            var bulunan = service.GetAll(false).Where(x => x.Email == email && x.Passwords == Sifre).FirstOrDefault();

            if (bulunan is not null)
            {
                var clamims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, bulunan.Email),
                   new Claim(ClaimTypes.Role, bulunan.Roles),
                };
                var claimsIdentity = new ClaimsIdentity(clamims,"Cookies");

                var claimsprincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsprincipal);
                return Redirect("/admin/Kategoriler");
            }
            else
            {
                ViewBag.mesaj = "Email veya Şifre Hatalı";
                return View();
            }
        }
    }
}
