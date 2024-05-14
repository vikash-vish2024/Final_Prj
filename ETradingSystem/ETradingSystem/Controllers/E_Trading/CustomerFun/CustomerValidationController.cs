using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Models;
namespace ETradingSystem.Controllers.E_Trading.CustomerFun
{
    public class CustomerValidationController : Controller
    {
        public static decimal cust_id;
        private readonly E_TradingDBEntities db; 

        public CustomerValidationController()
        {
            db = new E_TradingDBEntities(); 
        }
        // GET: Customer
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            if (IsValidCustomer(email, password))
            {
                cust_id = db.Customers.Where(c => c.Customer_Email == email).Select(c => c.Customer_Id).FirstOrDefault();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.InvalidLogin = "Invalid Customer Email or password.";
                return View();
            }
        }

        private bool IsValidCustomer(string email, string password)
        {
            string Email = db.Customers.Where(x => x.Customer_Email == email).Select(x => x.Customer_Email).FirstOrDefault();
            string Password = db.Customers.Where(x => x.Customer_Email == email).Select(x => x.Password).FirstOrDefault();
            if (email == Email && password == Password)
            {
                return true;
            }
            return false;
        }
    }
}