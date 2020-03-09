using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ELTPServiceLayer;
using ELTPViewModel;
using ELTPCaseStudy.CustomFilter;


namespace ELTPCaseStudy.Controllers
{
    public class AccountController : Controller
    {
        readonly IUsersService us;

        public AccountController() 
        { 

        }
        public AccountController(IUsersService us)
        {
            this.us = us;
        }

        public IUsersService Us => us;

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                UserViewModel uvm = this.us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.UserID;
                    Session["CurrentUserName"] = uvm.Name;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserIsAdmin"] = uvm.IsAdmin;

                    if (uvm.IsAdmin)
                    {
                        return RedirectToRoute(new { area = "admin", controller = "Home", action = "Index" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Data");
                }
            }

            return View(lvm);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        [UserAuthorizationFilterAttr]
        public ActionResult ChangeProfile()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel uvm = this.us.GetUsersByUserID(uid);
            EditUserDetailsViewModel eudvm = new EditUserDetailsViewModel() { Name = uvm.Name, Email = uvm.Email, Mobile = uvm.Mobile, UserID = uvm.UserID };
            return View(eudvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttr]
        public ActionResult ChangeProfile(EditUserDetailsViewModel eudvm)
        {
            eudvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
            this.us.UpdateUserDetails(eudvm);
            Session["CurrentUserID"] = eudvm.Name;
            return RedirectToAction("Index", "Home");
        }

        [UserAuthorizationFilterAttr]
        public ActionResult ChangePassword()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel uvm = this.us.GetUsersByUserID(uid);
            EditUserPasswordViewModel eupvm = new EditUserPasswordViewModel() { Email = uvm.Email, Password = "", ConfirmPassword = "", UserID = uvm.UserID };
            return View(eupvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttr]
        public ActionResult ChangePassword(EditUserPasswordViewModel eupvm)
        {
            eupvm.UserID = Convert.ToInt32(Session["CurrentUserID"]);
            this.us.UpdateUserPassword(eupvm);
            return RedirectToAction("Index", "Home");
        }
    }
}