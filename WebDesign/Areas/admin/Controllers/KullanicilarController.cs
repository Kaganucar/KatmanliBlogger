using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin"), Authorize(Roles ="Admin")]
    public class KullanicilarController : Controller
    {
        private IUserService service;

        public KullanicilarController(IUserService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll(true));
        }
        [HttpGet] // Görselin Ekrana gelmesini sağlar
        public IActionResult Ekle()
        {
            return View();
        }

        // Görselde İnput Butonuna tıklandığında Gelen Request'i yakalayıp işlem yapmamızı sağlar.
        [HttpPost]
        public IActionResult Ekle(TBLUser data)
        {
            ViewBag.message = service.Ekle(data);
            return View();
        }

        [HttpGet]
        [Route("/Admin/Kullanici/Guncelle/{id}")]
        public IActionResult Guncelle(int id)
        {
            return View(service.GetById(id));
        }

        // Görselde İnput Butonuna tıklandığında Gelen Request'i yakalayıp işlem yapmamızı sağlar.
        [HttpPost]
        [Route("/Admin/Kullanici/Guncelle/{id}")]
        public IActionResult Guncelle(TBLUser data, int id)
        {
            var bulunan = service.GetById(id);
            bulunan.Email = data.Email;
            bulunan.Passwords = data.Passwords;
            ViewBag.message = service.Guncelle(bulunan);
            return View(service.GetById(id));
        }

        [HttpGet]
        [Route("/Admin/Kullanici/Sil/{id}")]
        public IActionResult Sil(int id)
        {
            service.Sil(id);
            return Redirect("/admin/Kullanicilar");
        }
    }
}
