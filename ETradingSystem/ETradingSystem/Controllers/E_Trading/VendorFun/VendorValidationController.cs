using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Models;
namespace ETradingSystem.Controllers.E_Trading.VendorFun
{
    public class VendorValidationController : Controller
    {
        private readonly E_TradingDBEntities db; 
        public VendorValidationController()
        {
            db = new E_TradingDBEntities(); 
        }
        // GET: Vendor
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (IsValidVendor(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.InvalidLogin = "Invalid Admin Email or Password.";
                return View();
            }
        }

        private bool IsValidVendor(string email, string password)
        {
            string Email = db.Vendors.Where(x => x.Vendor_Email == email).Select(x => x.Vendor_Email).FirstOrDefault();
            string Password = db.Vendors.Where(x => x.Vendor_Email == email).Select(x => x.Passowrd).FirstOrDefault();
            if (email == Email && password == Password)
            {
                return true;
            }
            return false;
        }
    }
}