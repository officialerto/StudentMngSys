using StudentManagementProject.Models.Context;
using StudentManagementProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementProject.Controllers
{
    public class AccountController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Students.SingleOrDefault(s => s.email == model.Email && s.password == model.Password)
                           ?? db.Teachers.SingleOrDefault(t => t.email == model.Email && t.Password == model.Password);

                if (user != null)
                {
                    // Authentication and session logic here
                    Session["UserId"] = user.UserId;
                    Session["UserRole"] = user is Student ? "Student" : "Teacher";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}