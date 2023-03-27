using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "Category");
        }
    }
}
