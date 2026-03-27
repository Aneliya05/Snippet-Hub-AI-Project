using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseCRUDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
