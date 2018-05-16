using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodStore.DAL;
using FastFoodStore.Models;

namespace FastFoodStore.Controllers
{
    public class HomeController : Controller
    {
        private FastFoodStoreContext _context;
        public HomeController(FastFoodStoreContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.User.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                _context.User.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.LastName+"is sucessfully";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var account = _context.User.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                if (account != null)
                {
                    Session["UserID"] = account.UserID.ToString();
                    Session["UserName"] = account.UserName.ToString();
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password is wrong");
                }
            
            return View();
        }
        public ActionResult Welcome()
        {
            if (Session["UserID"] != null)
            {
                ViewBag.UserName = Session["UserName"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}