using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SnippetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
