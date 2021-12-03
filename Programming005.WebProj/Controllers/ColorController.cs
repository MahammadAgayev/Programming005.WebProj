using Microsoft.AspNetCore.Mvc;

namespace Programming005.WebProj.Controllers
{
    public class ColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
