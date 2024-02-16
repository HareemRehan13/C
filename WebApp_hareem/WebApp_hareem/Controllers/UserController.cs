using Microsoft.AspNetCore.Mvc;

namespace WebApp_hareem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
