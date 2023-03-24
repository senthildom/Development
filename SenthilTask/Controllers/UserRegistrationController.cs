using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenthilTask.Models;
using System;
using System.Security.Principal;

namespace SenthilTask.Controllers
{
    public class UserRegistrationController : Controller
    {
        private readonly ApplicationUserClass _auc;
        public UserRegistrationController(ApplicationUserClass auc)
        {
            _auc = auc;
        }

        [HttpGet]

        public IActionResult Index()
        {
            UserClass loginModel = new UserClass();
            ModelState.Remove("Password");
            return View(loginModel);
        }

        [HttpPost]
        public IActionResult Index(UserClass loginModel)
        {
            ModelState.Remove("Password");
            // TestDBContext testDBContext = new TestDBContext();
            var status = _auc.UserReg.Where(m => m.Email == loginModel.Email && m.Password == loginModel.Password).FirstOrDefault();
            //var status = testDBContext.UserLoginMasters.Where(m => m.LoginId == loginModel.LoginId && m.Password == loginModel.Password).FirstOrDefault();
            if (status != null)
            {
                if((loginModel.FirstName.ToUpper() == "ADMIN") || (loginModel.Email.ToLower()== "admin@gmail.com"))
                {
                    ViewBag.Message = "Admin Successfull login";
                    return RedirectToAction("ProductList", "Product");
                }
                else
                {
                    ViewBag.Message = "User Successfull login";
                    return RedirectToAction("UserProductList", "Product");
                }
                
            }
            else
            {
                ViewBag.Message = "Invalid login detail.";
            }
            return View(loginModel);
        }

        public IActionResult Login()
        {
            UserClass loginModel = new UserClass();

            return View(loginModel);
        }

        [HttpPost]
        public IActionResult Login(UserClass loginModel)
        {
            // TestDBContext testDBContext = new TestDBContext();
            var status = _auc.UserReg.Where(m => m.Email == loginModel.Email && m.Password == loginModel.Password).FirstOrDefault();
            //var status = testDBContext.UserLoginMasters.Where(m => m.LoginId == loginModel.LoginId && m.Password == loginModel.Password).FirstOrDefault();
            if (status != null)
            {
                if (loginModel.Email == "Admin@gmail.com")
                {
                    ViewBag.Message = "Admin Successfull login";
                    return RedirectToAction("ProductList", "Product");
                }
                else
                {
                    ViewBag.Message = "User Successfull login";
                    return RedirectToAction("UserProductList", "Product");
                }

            }
            else
            {
                ViewBag.Message = "Invalid login detail.";
            }
            return View(loginModel);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserClass uc)
        {
            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "The user "+uc.FirstName+" is saved successfully..!";
            return View();
        }

        public ActionResult LogOff()
        {
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            return RedirectToAction("Index", "UserRegistration");
        }

        public ActionResult Clear()
        {
            ModelState.Clear();
            return RedirectToAction("Create", "UserRegistration");
        }
    }
}
