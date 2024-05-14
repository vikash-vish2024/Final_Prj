using ETrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ETrading.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Admin model)
        {
            using (var context = new E_Trading_SystemEntities())
            {
                bool isValid = context.Admins.Any(x => x.Admin_Email == model.Admin_Email && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Admin_Email, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid AdminId or Password");
                ViewBag.ErrorMessage = "Invalid AdminId or Password";
                return View();

            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
