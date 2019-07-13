using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Cube.Mlm.Models;
using Deventure.Common.Response;
using Cube.Common.Constants;
using Cube.DataLayer;
using Cube.BussinessLogic.Core;
using System.Web.Security;
using LoggingService;
using Cube.BusinessLogic.Email;
using Cube.Models;

namespace Cube.Mlm.Controllers
{
    [Authorize]
    public partial class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]

        public virtual async Task<JsonResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ResponseFactory.InvalidInputResponse);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true

            try
            {
                var applicationUser = await CheckEmailAndPassword(model.Email, model.Password).ConfigureAwait(false);
                if (applicationUser == null)
                {
                    return Json(ResponseFactory.ErrorReponse);
                }

                var user = await UserCore.GetByEmailAsync(model.Email, new[]
                            {
                                $"{nameof(DataLayer.User.AspNetUser)}.{nameof(AspNetUser.AspNetRoles)}"
                            });
                if (user == null)
                {
                    return Json(ResponseFactory.ErrorReponse);
                }

                if (user.AspNetUser.AspNetRoles.Any(role => role.Id == AuthorizationConstants.TEAM_LEADER_ROLE_ID))
                {
                    CreateCookie(applicationUser.UserName, applicationUser.Id);
                    return Json(ResponseFactory.SuccessResponse);
                }
            }
            catch (Exception ex)
            {
                LoggingService.LogHelper.LogException<AccountController>(ex);
            }
            return Json(ResponseFactory.ErrorReponse);
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public virtual async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(Models.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public virtual async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.EmailForgot);
                
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var emailPath = HttpContext.Server.MapPath(MVC.Emails.Views.ForgotPasswrodEmailView);
                var callbackUrl = Url.Action(MVC.Account.ActionNames.ResetPassword, MVC.Account.Name, new { userId = user.Id, code = code, email = model.EmailForgot }, protocol: Request.Url.Scheme);
                var response = await EmailCore.SendGenericEmail(emailPath, new[] { model.EmailForgot },
                                   "Forgot Password", new ForgotPasswordEmailViewModel
                                   {
                                       FullName = user.UserName,
                                       Link = callbackUrl,
                                   });
                await UserTokenCore.AddUserTokenAsync(user.Id, code).ConfigureAwait(false);
            }

            
            return Json(ResponseFactory.SuccessResponse);

        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public virtual ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public virtual ActionResult ResetPassword(string code)
        {
            var model = new ResetPasswordViewModel
            {
                Token = code
            };

            if (model.Token == null)
            {
                return View("Error");
            }
            return View(model);
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]

        public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var aspNetUserId = await UserTokenCore.GetUserIdByTokenAsync(model.Token).ConfigureAwait(false);
                if (aspNetUserId == string.Empty)
                {
                    LogHelper.LogInfo<AccountController>($"Invalid application user for token {model.Token}");
                    return Json(ResponseFactory.Error());
                }

                var applicationUser = await UserManager.FindByIdAsync(aspNetUserId);
                if (applicationUser == null)
                {
                    LogHelper.LogInfo<AccountController>($"Invalid application user for aspnetUser Id {aspNetUserId}");
                    return Json(ResponseFactory.Error());
                }
                var result = await UserManager.UpdatePasswordAsync(applicationUser, model.Password).ConfigureAwait(false);
                if (result.Succeeded)
                {
                    // sign out 
                    if (System.Web.HttpContext.Current != null)
                    {
                        var cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                        if (cookie != null)
                        {
                            var httpCookie = HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName];
                            if (httpCookie != null)
                            {
                                httpCookie.Expires = DateTime.Now.AddDays(-1d);
                            }
                        }
                    }

                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.Request.Cookies.Clear(); // clear all cookies, to start a fresh session

                    await UserTokenCore.RemoveUserTokenByTokenAsync(model.Token).ConfigureAwait(false);
                    return Json(ResponseFactory.SuccessResponse);
                }
                else
                {
                    return Json(ResponseFactory.CreateResponse(false, ResponseCode.ErrorAnErrorOccurred, result.Errors));
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogException<AccountController>(ex);
            }

            return Json(ResponseFactory.ErrorReponse);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public virtual ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public virtual async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region private methods
        protected async Task<ApplicationUser> CheckEmailAndPassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            var aspNetUser = await UserManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (aspNetUser == null)
            {
                return null;
            }

            var validPassword = await UserManager.CheckPasswordAsync(aspNetUser, password).ConfigureAwait(false);

            return !validPassword ? null : aspNetUser;
        }

        protected void CreateCookie(string userName, string id)
        {
            var ticketsToken = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(90), true, id,
                FormsAuthentication.FormsCookiePath);

            var cookiestr = FormsAuthentication.Encrypt(ticketsToken);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)
            {
                Expires = ticketsToken.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };
            Response.Cookies.Add(cookie);
        }


        #endregion
        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
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