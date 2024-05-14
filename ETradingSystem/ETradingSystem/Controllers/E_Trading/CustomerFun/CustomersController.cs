using ETradingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Controllers.E_Trading.VendorFun;
namespace ETradingSystem.Controllers.E_Trading.CustomerFun
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private readonly Product p;
        //Order o = new Order();
        private readonly E_TradingDBEntities db;
        public CustomersController()
        {
            db = new E_TradingDBEntities();
        }

        public ActionResult PlaceOrder()
        {
            if (CustomerValidationController.cust_id == null)
            {
                return RedirectToAction("Login", "CustomerValidation");
            }
            else
            {
                if (p.Status == "Available" && p.isdeleted == "No")
                {
                    Random r = new Random();
                    int purchaseId = r.Next(1111, 9999);
                    int productId = ProductsController.productId;
                    int customerId = (int)CustomerValidationController.cust_id;
                    db.orderPlaced(purchaseId, productId, customerId);
                    int orderId = r.Next(100, 999);
                    db.orderDetail(orderId, purchaseId, productId);
                    db.updateStatus(productId);
                    db.updateStatus(productId);
                    return RedirectToAction("Index","Product");
                }
                else
                {
                    return ViewBag("Product is out of stock or deleted.");
                }
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Hint_Id = new SelectList(db.Hints, "Hint_Id", "Questions");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_Id,Customer_Name,Customer_Email,Date_Of_Birth,Address,Balance,Mobile_Number,Password,Hint_Id,Hint_Answer,Status")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Status = "Active";
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hint_Id = new SelectList(db.Hints, "Hint_Id", "Questions", customer.Hint_Id);
            return View(customer);
        }

    }
}