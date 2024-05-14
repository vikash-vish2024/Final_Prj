using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETradingSystem.Controllers.E_Trading.CustomerFun;
using ETradingSystem.Models;

namespace ETradingSystem.Controllers.E_Trading.VendorFun
{
    public class Products1Controller : Controller
    {
        private E_TradingDBEntities db = new E_TradingDBEntities();

        // GET: Products1
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Vendor);
            return View(products.ToList());
        }

        // GET: Products1/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products1/Create
        public ActionResult Create()
        {
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "Vendor_Name");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_Id,Vendor_Id,Product_Name,Brand,Color,Price,Available_Stock,Status,isdeleted,ImageURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "Vendor_Name", product.Vendor_Id);
            return View(product);
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "Vendor_Name", product.Vendor_Id);
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_Id,Vendor_Id,Product_Name,Brand,Color,Price,Available_Stock,Status,isdeleted,ImageURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "Vendor_Name", product.Vendor_Id);
            return View(product);
        }

        // GET: Products1/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            if (CustomerValidationController.cust_id == null)
            {
                return RedirectToAction("Login", "CustomerValidation");
            }
            else
            {
                Product p = new Product();
                //if (p.Status == "Available")
                //{

                //    Random r = new Random();
                //    int purchaseId = r.Next(1111, 9999);
                //    int productId =(int) id; /*ProductsController.productId;*/
                //    int customerId = 1; /*(int)CustomerValidationController.cust_id;*/
                //    db.orderPlaced(purchaseId, productId, customerId);
                //    int orderId = r.Next(100, 999);
                //    db.orderDetail(orderId, purchaseId, productId);
                //    db.updateStatus(productId);
                //    db.updateStatus(productId);
                //    return RedirectToAction("Index", "Product");
                //}
                //else
                //{
                //    return RedirectToAction("Index"); ;
                //}

                Random r = new Random();
                int purchaseId = r.Next(1111, 9999);
                int productId = (int)id; /*ProductsController.productId;*/
                int customerId = 1; /*(int)CustomerValidationController.cust_id;*/
                db.orderPlaced(purchaseId, productId, customerId);
                int orderId = r.Next(100, 999);
                db.orderDetail(orderId, purchaseId, productId);
                db.updateStatus(productId);
                db.updateStatus(productId);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
