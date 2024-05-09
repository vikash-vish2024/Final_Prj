using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETrading.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Customer()
        {
            ViewBag.Messenge = "Customer page";
            return View();
        }
        public ActionResult Vendor()
        {
            ViewBag.Messenge = "Vendor page";
            return View();
        }
        public ActionResult Welcome()
        {
            ViewBag.Messenge = "Welcome page";
            return View();
        }
    }
}
