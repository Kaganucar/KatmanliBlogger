using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Areas.admin.Controllers
{
    [Area("admin")]
    public class CikisController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/login");
        }
    }
}
