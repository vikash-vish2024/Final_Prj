using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETradingSystem.Controllers.E_Trading.Vendor
{
    public class VendorValidationController : Controller
    {
        //private readonly E_Trading_SystemEntities db; // Replace YourDbContext with your actual DbContext class

        //public VendorController()
        //{
        //    db = new E_Trading_SystemEntities(); // Initialize your DbContext
        //}
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(string email, string password)
        //{
        //    // Your login logic goes here
        //    // Example:
        //    if (IsValidVendor(email, password))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        // If login fails, set an error message and return to the login page
        //        ViewBag.InvalidLogin = "Invalid Admin Email or Password.";
        //        return View();
        //    }
        //}

        //private bool IsValidVendor(string email, string password)
        //{
        //    string Email = db.Vendor.Where(x => x.Vendor_Email == email).Select(x => x.Vendor_Email).FirstOrDefault();
        //    string Password = db.Vendor.Where(x => x.Vendor_Email == email).Select(x => x.Password).FirstOrDefault();
        //    if (email == Email && password == Password)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}