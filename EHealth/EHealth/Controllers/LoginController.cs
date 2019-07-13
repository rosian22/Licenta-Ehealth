using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Web;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using System.Linq;
using System.Collections.Generic;
using EHealth.Models;
using EHealth.BusinessLogic.Workflow;
using DataLayer.EHealth;
using EHealth.DataLayer.Repositories;
using Microsoft.AspNet.Identity.Owin;

namespace EHealth.Controllers
{
    [AllowAnonymous]
    public partial class LoginController : GenericBaseController
    {
        public LoginController()
        {
        }

        public LoginController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) : base(userManager, signInManager)
        {
        }

        [HttpGet]
        public virtual ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("~/Views/Account/Login.cshtml");
        }

        //[HttpGet]
        //public virtual ActionResult NavigateHome()
        //{
        //    return RedirectToAction(MVC.Admin.Shift.ActionNames.Index, MVC.Admin.Shift.Name,
        //        new { area = MVC.Admin.Name });
        //}

        //
        // POST: /Account/Login
        //[HttpPost]
        //public virtual async Task<ActionResult> Login(LoginModel model)
        //{
        //    var response = ResponseFactory.Error<StringWrapper>();

        //    if (!ModelState.IsValid)
        //    {
        //        return null;
        //    }

        //    var result = await CheckUserCredentials(model.Email, model.Password).ConfigureAwait(false);
        //    if (result)
        //    {
        //        return null;
        //    }

        //    var backLogin = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);


        //    return RedirectToAction("Index", "Home");
        //}

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("/Login/Index");
            }

            var cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                var httpCookie = HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName];
                if (httpCookie != null)
                {
                    httpCookie.Expires = DateTime.Now.AddDays(-1d);
                }
            }

            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            HttpContext.Request.Cookies.Clear(); // clear all cookies, to start a fresh session

            return RedirectToAction("/Login/Index");
        }

        //public virtual async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        RedirectToAction("Login/Index");
        //    }

        //    var createdUserResponse = await UserCore.RegisterUser(model).ConfigureAwait(false);
        //    if (!ResponseFactory.IsSuccessful(createdUserResponse))
        //    {
        //        RedirectToAction("Login/Index");
        //    }

        //    RedirectToAction("Login/Index");
        //}

        public static Response CheckEmailCollision(string email)
        {
            var response = ResponseFactory.Error<AspNetUser>();
            if (string.IsNullOrWhiteSpace(email))
            {
                return response;
            }

            var existingAspNetUser = AspNetUserCore.GetByEmail(email);
            if (existingAspNetUser != null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.Success();
        }

        public async Task<ActionResult> RegisterAdmin(RegisterViewModel registerModel, bool refreshFromDb = false)
        {
            var createUserResponse = CheckEmailCollision(registerModel.Email);
            if (!ResponseFactory.IsSuccessful(createUserResponse))
            {
                return View("~/Views/Account/Login.cshtml");
            }

            var passwordHash = HashPassword(registerModel.Password);
            registerModel.userType = (int)UserType.ADMIN;
            registerModel.PhoneNumber = "0123456789";
            registerModel.Id = Guid.NewGuid();

            var registerUserResponse = await AspNetUserCore.Register(registerModel, passwordHash).ConfigureAwait(false);
            if (!ResponseFactory.IsSuccessful(registerUserResponse))
            {
                return View("~/Views/Account/Login.cshtml");
            }

            return View("~/Views/Account/Login.cshtml");
        }

        protected async Task<bool> CheckUserCredentials(string email, string password)
        {
            try
            {
                var applicationUser = await CheckEmailAndPassword(email, password).ConfigureAwait(false);
                if (applicationUser == null)
                {
                    return false;
                }

                IList<string> roleIds = null;

                var roleIdList = await AspNetRoleCore.GetListAsync(t => t.Id != Guid.Empty.ToString()).ConfigureAwait(false);
                if (roleIdList == null)
                {
                    roleIds = roleIdList.Select(t => t.Id).ToList();
                }



                var isUserApproved = await AspNetUserCore.IsUserIdAuthorizedAsync(applicationUser.Id, roleIds.ToList()).ConfigureAwait(false);
                if (!isUserApproved)
                {
                    return false;
                }

                CreateCookie(applicationUser.UserName, applicationUser.Id);

                return true;
            }
            catch (Exception ex)
            {
                //LogHelper.LogException<AccountController>(ex);
            }
            return false;
        }

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
    }
}