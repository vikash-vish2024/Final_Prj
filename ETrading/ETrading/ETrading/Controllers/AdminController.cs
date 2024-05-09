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
        private readonly E_Trading_SystemEntities db; // Replace YourDbContext with your actual DbContext class

        public AdminController()
        {
            db = new E_Trading_SystemEntities(); // Initialize your DbContext
        }
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Your login logic goes here
            // Example:
            if (IsValidAdmin(email, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If login fails, set an error message and return to the login page
                ViewBag.InvalidLogin = "Invalid admin ID or password.";
                return View();
            }
        }

        private bool IsValidAdmin(string email, string password)
        {
            string Email = db.Admins.Where(x => x.Admin_Email == email).Select(x => x.Admin_Email).FirstOrDefault();
            string Password = db.Admins.Where(x => x.Admin_Email == email).Select(x => x.Password).FirstOrDefault();
            if (email == Email && password == Password)
            {
                return true;
            }
            return false;
        }
    }
}