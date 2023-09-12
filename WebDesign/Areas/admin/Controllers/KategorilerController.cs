using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin"),Authorize(Roles = "Admin,Uye")]
    public class KategorilerController : Controller
    {
        private ICategoriesService service;

        public KategorilerController(ICategoriesService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet] // Görselin Ekrana gelmesini sağlar
        public IActionResult Ekle()
        {
            return View();
        }

        // Görselde İnput Butonuna tıklandığında Gelen Request'i yakalayıp işlem yapmamızı sağlar.
        [HttpPost]
        public IActionResult Ekle(TBLCategories data)
        {
            ViewBag.message = service.Ekle(data);
            return View();
        }

        [HttpGet]
        [Route("/Admin/Guncelle/{id}")]
        public IActionResult Guncelle(int id)
        {
            return View(service.GetById(id));
        }

        // Görselde İnput Butonuna tıklandığında Gelen Request'i yakalayıp işlem yapmamızı sağlar.
        [HttpPost]
        [Route("/Admin/Guncelle/{id}")]
        public IActionResult Guncelle(TBLCategories data, int id)
        {
            var bulunan = service.GetById(id);
            bulunan.CategoryName = data.CategoryName;
            ViewBag.message = service.Guncelle(bulunan);
            return View(service.GetById(id));
        }

        [HttpGet]
        [Route("/Admin/Sil/{id}")]
        public IActionResult Sil(int id)
        {
            service.Sil(id);
            return Redirect("/admin/Kategoriler");
        }
    }
}
