using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using SSZ.Filters;
using SSZ.Models;

namespace SSZ.Controllers {
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller {

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login() {
            Logout model = new Logout();
            List<systemsap> spis = new List<systemsap>();
            spis.Add(new systemsap { Name = "AZP", Text = "AZP - продуктивная система" });
            spis.Add(new systemsap { Name = "AZQ", Text = "AZQ - тестовая система" });
            spis.Add(new systemsap { Name = "AZD", Text = "AZD - Developer system" });
            spis.Add(new systemsap { Name = "AZD100", Text = "AZD100 - Developer system" });
            SelectList sys = new SelectList(spis, "Name", "Text");
            ViewBag.SysSap = sys;
            ViewBag.SystemM = false;
            model.Lang = "RU";
            if (HttpContext.Request.Cookies["Smena"] != null)
            {
                string coc = HttpContext.Request.Cookies["Smena"].Value.ToString();
                if (coc == "AZP" || coc == "AZQ" || coc == "AZD" || coc == "AZD100")
                    model.SystemSap = coc;

            }

            return View(model);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Logout model, string returnUrl) {
            if(ModelState.IsValid) {
                if(WebSecurity.Login(model.Username, model.Password, persistCookie: false)) {
                    return Redirect(returnUrl ?? "/"); 
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            List<systemsap> spis = new List<systemsap>();
            spis.Add(new systemsap { Name = "AZP", Text = "AZP - продуктивная система" });
            spis.Add(new systemsap { Name = "AZQ", Text = "AZQ - тестовая система" });
            spis.Add(new systemsap { Name = "AZD", Text = "AZD - Developer system" });
            spis.Add(new systemsap { Name = "AZD100", Text = "AZD100 - Developer system" });
            SelectList sys = new SelectList(spis, "Name", "Text");
            ViewBag.SysSap = sys;
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff() {
            //WebSecurity.Logout();
            return Redirect("/");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model) {
            if(ModelState.IsValid) {
                // Attempt to register the user
                            try {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch(MembershipCreateUserException e) {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
                        }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword() {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model) {
            if(ModelState.IsValid) {
                bool changePasswordSucceeded;
                try {
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                }
                catch(Exception) {
                    changePasswordSucceeded = false;
                }
                if(changePasswordSucceeded) {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess() {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch(createStatus) {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}