using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kondominium.Controllers
{
    public class AccountController : Controller
    {

        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        public AccountController()
        {
        }


        //Anotacion Ejemplo test test2


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        public ActionResult Login(ZTAdminEntities.Security.UserEntity model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }



            var ValidarLogin = new ZTAdminBL.Security.UserData().ValidatePassword(new ZTAdminEntities.Security.UserValidationEntity(model.Email, model.Password));

            if (ValidarLogin.Error == 0)
            {
                Session["MenuMaster"] = LlenarMenu(model.Email);

                string groups = "Usuarios ZTAdmin";

                bool isCookiePersistent = false;
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(60), isCookiePersistent, groups);

                //Encrypt the ticket.
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                //Create a cookie, and then add the encrypted ticket to the cookie as data.
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                if ((isCookiePersistent == true))
                {
                    authCookie.Expires = authTicket.Expiration;
                }
                //Add the cookie to the outgoing cookies collection.
                Response.Cookies.Add(authCookie);


                new ZTAdmin.Class.Log().Set("Login", model.Email, Request.UserHostName, System.Reflection.Assembly.GetExecutingAssembly().ToString());



                return RedirectToLocal(returnUrl);
            }
            else if (ValidarLogin.Error == 99)
            {
                ModelState.AddModelError("", "Usuario Erroneo, favor validar");
                return View(model);
            }
            else if (ValidarLogin.Error == 98)
            {
                ModelState.AddModelError("", "Password Erroneo, favor validar");
                return View(model);
            }


            return View(model);





        }
        public List<Kondominium_Entities.Utilites.MenuEntity> LlenarMenu(string Userid)
        {
            List<Kondominium_Entities.Utilites.MenuEntity> _menus = new ZTAdminBL.Security.ProfileMenuPermissionData().GetByUserId(Userid).Select(x => new Kondominium_Entities.Utilites.MenuEntity
            {
                UserId = x.UserId,
                Active = x.Active,
                ProfileId = x.ProfileId,
                ProfileActive = x.ProfileActive,
                ProfileDescription = x.ProfileDescription,
                SubMenuPermissionId = x.SubMenuPermissionId,
                SubMenuId = x.SubMenuId,
                Enabled = x.Enabled,
                SubMenu = x.SubMenu,
                Controller = x.Controller,
                Action = x.Action,
                MainMenuId = x.MainMenuId,
                MainMenu = x.MainMenu,
                Detail = x.Detail,
                Icon = x.Icon,
                Agrupacion = x.Agrupacion
            }
               ).ToList();

            if (System.Web.HttpContext.Current.Session == null)
            {

                System.Web.HttpContext.Current.Session.Add("MenuMaster", _menus);
            }
            else
            {
                System.Web.HttpContext.Current.Session["MenuMaster"] = _menus;
            }

            //Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session
            //                Session["MenuMaster"] = _menus; //Bind the _menus list to MenuMaster session
            //              Session["UserName"] = Userid;

            return _menus;
        }





        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }




        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }



        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }





        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            
            new ZTAdmin.Class.Log().Set("LogOff", HttpContext.User.Identity.Name, Request.UserHostName, System.Reflection.Assembly.GetExecutingAssembly().ToString());
            return RedirectToAction("Login", "Account");
            ///return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_userManager != null)
        //        {
        //            _userManager.Dispose();
        //            _userManager = null;
        //        }

        //        if (_signInManager != null)
        //        {
        //            _signInManager.Dispose();
        //            _signInManager = null;
        //        }
        //    }

        //    base.Dispose(disposing);
        //}

        #region  "Zt"   

        public new ActionResult Profile()
        {
            var userBl = new ZTAdminBL.Security.UserData().GetById(HttpContext.User.Identity.Name);
            var user = new ZTAdminEntities.Security.UserEntity();

            user.Name = userBl.Name.Trim();
            user.LastName = userBl.LastName.Trim();
            user.Active = userBl.Active;
            user.Email = userBl.Email.Trim();
            user.Password = userBl.Password;
            user.RolId = userBl.RolId.Trim();
            user.UserExecute = userBl.UserExecute;
            user.UserId = userBl.UserId;
            //user.userpermission = userBl.userpermission;


            return View(user);
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        public new ActionResult Profile(ZTAdminEntities.Security.UserEntity user)
        {
            try
            {
                var userBl = new ZTAdminBL.Security.UserData();

                userBl.InsertUpdateUsers(new ZTAdminEntities.Security.UserEntity
                {
                    Active = user.Active,
                    Email = user.Email,
                    LastName = user.LastName,
                    Name = user.Name,
                    Password = "000000000000000",
                    RolId = user.RolId,
                    UserId = user.UserId,
                    UserExecute = user.UserId

                });

                ViewBag.Successful = "Datos Actualizados!";
                ViewBag.MessageSucces = "Datos Actualizados!";

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.MessageError = ex.Message;
            }

            return View(user);
        }



        public ActionResult Log_Action()
        {

            var log = new List<ZTAdminEntities.Security.Log_ActionEntity>();
            var log1 = new ZTAdminEntities.Security.Log_ActionEntity();
            var logdate = new ZTAdminBL.Security.Log_ActionData().GetByUserId(HttpContext.User.Identity.Name, DateTime.Today.Add(new TimeSpan(-30, 0, 0, 0)), DateTime.Today.Add(new TimeSpan(1, 0, 0, 0)));

            foreach (var item in logdate)
            {
                var logx = new ZTAdminEntities.Security.Log_ActionEntity();
                logx.Action = item.Action;
                logx.DateTimeOfAction = item.DateTimeOfAction;
                logx.Host = item.Host;
                logx.RowId = item.RowId;
                logx.UserId = item.UserId;

                log.Add(logx);


            }

            return View(log);
        }
        // POST: 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Log_Action(String FromDate, String ToDate)
        {

            var log = new List<ZTAdminEntities.Security.Log_ActionEntity>();
            var log1 = new ZTAdminEntities.Security.Log_ActionEntity();
            var logdate = new ZTAdminBL.Security.Log_ActionData().GetByUserId(HttpContext.User.Identity.Name, DateTime.Parse(FromDate), DateTime.Parse(ToDate));

            foreach (var item in logdate)
            {
                var logx = new ZTAdminEntities.Security.Log_ActionEntity();
                logx.Action = item.Action;
                logx.DateTimeOfAction = item.DateTimeOfAction;
                logx.Host = item.Host;
                logx.RowId = item.RowId;
                logx.UserId = item.UserId;

                log.Add(logx);


            }

            return View(log);
        }



        #endregion


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private System.Security.Principal.IIdentity AuthenticationManager
        {
            get
            {
                return HttpContext.User.Identity;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

    }
}