//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace ETradingSystem.Controllers.E_Trading.Vendor
//{
//    public class VendorValidationController : Controller
//    {
//        // GET: VendorValidation
//        public ActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult login(Customer model)
//        {
//            using (var context = new EmpDbEntities())
//            {
//                bool isValid = context.User_Master.Any(x => x.UserID == model.UserID && x.UserPassword == model.UserPassword);
//                if (isValid)
//                {
//                    FormsAuthentication.SetAuthCookie(model.UserName, false);
//                    return RedirectToAction("Index", "Employees");
//                }
//                ModelState.AddModelError("", "Invalid user name and password");
//                return View();
//            }
//        }
//        public ActionResult Signup()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ActionResult Signup(User_Master model)
//        {
//            using (var context = new EmpDbEntities())
//            {
//                context.User_Master.Add(model);
//                context.SaveChanges();

//            }
//            return RedirectToAction("Login");
//        }

//        public ActionResult Logout()
//        {
//            FormsAuthentication.SignOut();
//            return RedirectToAction("Login");
//        }
//    }
//}