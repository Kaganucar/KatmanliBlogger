using BussinessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin"),Authorize(Roles = "Admin,Uye")]
    public class BloglarController : Controller
    {
        private IBlogService service;
        private ICategoriesService categoriesService;
        public BloglarController(IBlogService service,ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = categoriesService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(TBLBlog data,IFormFile dosya)
        {
            if (dosya is not null)
            {
                string uzanti = Path.GetExtension(dosya.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string DosyaAdi = Guid.NewGuid() + uzanti;
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{DosyaAdi}");
                    using var stream = new FileStream(KayitYolu, FileMode.Create);
                    dosya.CopyToAsync(stream);
                    data.Images = DosyaAdi;
                    ViewBag.message = service.Ekle(data);
                }
                else
                {
                    ViewBag.error = "jpeg veya jpg uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.error = "Lütfen Bir Dosya Seçiniz";
            }
            ViewBag.Kategoriler = categoriesService.GetAll();
            return View();
        }

        [HttpGet]
        [Route("/admin/Blog/Guncelle/{id}")]
        public IActionResult Guncelle(int id)
        {
            ViewBag.Kategoriler = categoriesService.GetAll();
            return View(service.GetById(id));
        }
        [HttpPost]
        [Route("/admin/Blog/Guncelle/{id}")]
        public IActionResult Guncelle(TBLBlog data, IFormFile dosya,int id)
        {
            var bulunan = service.GetById(id);
            if (dosya is not null)
            {
                string uzanti = Path.GetExtension(dosya.FileName);
                if (uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    string DosyaAdi = Guid.NewGuid() + uzanti;
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{DosyaAdi}");
                    using var stream = new FileStream(KayitYolu, FileMode.Create);
                    dosya.CopyToAsync(stream);
                    bulunan.Images = DosyaAdi;
                }
            }
            bulunan.BlogName = data.BlogName;
            bulunan.Explanation = data.Explanation;
            ViewBag.message = service.Guncelle(bulunan);

            ViewBag.Kategoriler = categoriesService.GetAll();
            return View(service.GetById(id));
        }
        [HttpGet]
        [Route("/admin/Blog/sil/{id}")]
        public IActionResult sil(int id)
        {
            service.Sil(id);
            return Redirect("/admin/Bloglar");
        }
    }
}
