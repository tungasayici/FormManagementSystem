using LenaSoftFormManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LenaSoftFormManagement.Controllers
{
    public class SecurityController : Controller
    {
        DbModel dbModel = new DbModel();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userDb = dbModel.Users.FirstOrDefault(x=>x.Username == user.Username && x.Password == user.Password);
            if(userDb != null)
            {
                FormsAuthentication.SetAuthCookie(userDb.Username, false);
                return RedirectToAction("Index", "Form");
            }
            else
            {
                ViewBag.Message = "Invalid username or password";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}