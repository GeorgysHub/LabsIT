using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopMVC.Controllers.Admin
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            string user = User.Identity.Name;
            if (!string.IsNullOrEmpty(user))
                return RedirectToAction("Dachboard");
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserM modile)
        {
            if (!ModelState.IsValid)
                return View(modile);
            bool isValid = false;
            if(modile.Username=="Admin" && modile.Password=="12345")
            {
                isValid = true;
            }
            if (!isValid)
            {
                ModelState.AddModelError("", "Неправильное имя пользователя или пароль.");
                return View(modile);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(modile.Username,modile.Rememder);
                return Redirect(FormsAuthentication.GetRedirectUrl(modile.Username, modile.Rememder));
            }
          
        }
    }
}