using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
