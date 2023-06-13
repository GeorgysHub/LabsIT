using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    public class DachboardController : Controller
    {
        // GET: Dachboard
        public ActionResult Index()
        {
            return View();
        }
    }
}