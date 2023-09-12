using Microsoft.AspNetCore.Mvc;

namespace WebDesign.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/admin/Login");
        }
    }
}
