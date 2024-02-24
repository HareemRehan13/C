using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_hareem.Data;
using WebApp_hareem.Models;

namespace WebApp_hareem.Controllers
{
    public class HomeController : Controller
    {
        private readonly dotnetContext db;
        public HomeController(dotnetContext db)
        {
            this.db = db;
        }   

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowRole()
        {
            return View(db.Roles.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            ViewBag.name = "Hareem";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
