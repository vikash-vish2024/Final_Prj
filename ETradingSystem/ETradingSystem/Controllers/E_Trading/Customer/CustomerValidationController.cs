using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETradingSystem.Controllers.E_Trading.Customer
{
    public class CustomerValidationController : Controller
    {
        // GET: CustomerValidation
        //private readonly E_Trading_SystemEntities db; // Replace YourDbContext with your actual DbContext class

        //public AdminController()
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
        //    if (IsValidCustomer(email, password))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        // If login fails, set an error message and return to the login page
        //        ViewBag.InvalidLogin = "Invalid Customer Email or password.";
        //        return View();
        //    }
        //}

        //private bool IsValidCustomer(string email, string password)
        //{
        //    string Email = db.Customer.Where(x => x.Customer_Email == email).Select(x => x.Admin_Email).FirstOrDefault();
        //    string Password = db.Customer.Where(x => x.Customer_Email == email).Select(x => x.Password).FirstOrDefault();
        //    if (email == Email && password == Password)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}