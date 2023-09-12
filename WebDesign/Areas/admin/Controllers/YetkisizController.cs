using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin")]
    public class YetkisizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
