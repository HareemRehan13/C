using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public IActionResult AddUser()
        {
            ViewBag.Roless = new SelectList(db.Roles, "RId", "RName");
            return View();
        }
        public IActionResult AddUser2(User u ,IFormFile images)
        {
            if(images != null && images.Length > 0)
            {
                var filename = Path.GetFileName(images.FileName);
                string folderpath = Path.Combine("wwwroot/assets/img",filename);
                var dbpath = Path.Combine("assets/img", filename);
                using (var stream = new FileStream(folderpath, FileMode.Create))
                {
                    images.CopyTo(stream);
                }
                u.UImg= dbpath;
                db.Add(u);
                db.SaveChanges();
                return RedirectToAction(nameof(ShowUser));
            }
          
            return View("AddUser");
        }
        public IActionResult ShowUser()
        {
            ViewBag.data = db.Users.Include("RIdNavigation").ToList();
            return View();
        }
        public IActionResult EditUser(int? id)
        {
            var data= db.Users.Where(x => x.RId == id).ToList();
            return View(data);
        }
        public IActionResult EditRole(int? id)
        {
            var data = db.Roles.FirstOrDefault(x=>x.RId == id);
            return View(data);
        }
        public IActionResult EditRole2(Role r)
        {
            db.Update(r);
            db.SaveChanges();
            return RedirectToAction("ShowRole");
        
        }
        public IActionResult DeleteRole(int? id)
        {
            var data = db.Roles.FirstOrDefault(x => x.RId == id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ShowRole");

        }
        public IActionResult AddRole()
        {
            return View();
        }
      
        public IActionResult AddRole2(Role r)
        {
            db.Add(r);
            db.SaveChanges();
            return RedirectToAction(nameof(ShowRole));
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
