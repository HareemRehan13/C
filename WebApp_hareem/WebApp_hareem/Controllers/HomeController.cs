﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics;
using System.Security.Claims;
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
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        public IActionResult Log(User U)
        {
            var res = db.Users.FirstOrDefault(x => x.UName == U.UName && x.UPass == U.UPass);
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if (res != null)
            {
                if (res.RId == 1)
                {
                    identity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name,res.UName),
                new Claim(ClaimTypes.NameIdentifier, res.UId.ToString()),
                new Claim(ClaimTypes.Role,"Admin")
                },
                CookieAuthenticationDefaults.AuthenticationScheme) ;
                    isAuthenticate = true;
                }
                else
                {
                    identity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name,res.UName),
                new Claim(ClaimTypes.NameIdentifier, res.UId.ToString()),
                new Claim(ClaimTypes.Role,"User")
            },


                     CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    if (res.RId == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            return View("Login");
        }
        
        public IActionResult Searching(IFormCollection abc)
        {
            var search = abc["searchedtext"];
            var data = db.Users.Include("RIdNavigation").Where(x => x.UName.Contains(search)).ToList();
            return View(data);
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
        [Authorize(Roles= "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditUser(int? id)
        {
            ViewBag.Roless = new SelectList(db.Roles, "RId", "RName");
            var data = db.Users.FirstOrDefault(x => x.RId == id);
            return View(data);
        }
        public IActionResult EditUser2(User u, IFormFile images)
        {
            if (images != null && images.Length > 0)
            {
                Guid r = Guid.NewGuid();
                var fileName = Path.GetFileNameWithoutExtension(images.FileName);
                var extension = images.ContentType.ToLower();
                var exten_pricese = extension.Substring(6);

                var unique_name = fileName + r + "." + exten_pricese;
                string imagesFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/assets/img");
                string filePath = Path.Combine(imagesFolder, unique_name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    images.CopyTo(stream);
                }
                var dbAdress = Path.Combine("assets/img", unique_name);
                u.UImg = dbAdress;
                db.Update(u);
                db.SaveChanges();

                return RedirectToAction(nameof(ShowUser));

            }
            return View("EditUser");
        }
        public IActionResult DeleteUser(int? id)
        {
            var data = db.Users.FirstOrDefault(x => x.UId == id);
            db.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ShowUser");

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
