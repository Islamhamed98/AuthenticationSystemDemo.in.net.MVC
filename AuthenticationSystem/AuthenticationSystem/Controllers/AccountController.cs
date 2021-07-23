using AuthenticationSystem.DataAccess;
using AuthenticationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace AuthenticationSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthSystemEntities _db = new AuthSystemEntities();


        [HttpGet]
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        // GET: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = _db.Users.Any(user => user.Username.ToLower() == userModel.Username.ToLower()
                                                && user.Password == userModel.UserPassword);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(userModel.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username and password");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegisterViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new Users();
                user.Username = userViewModel.Username;
                user.Password = userViewModel.ConfirmPassword;

                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}