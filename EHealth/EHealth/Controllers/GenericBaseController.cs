using EHealth;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataLayer.EHealth;
using CustomMembership;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;

namespace EHealth.Controllers
{
    public class GenericBaseController : Controller
    {
        protected ApplicationSignInManager mSignInManager;
        protected ApplicationUserManager mUserManager;

        public GenericBaseController()
        {
        }

        public GenericBaseController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        protected async Task<AspNetUser> GetLoggedUser(IList<string> navigationProperties = null)
        {
            return await AspNetUserCore.GetAsync(GetMyAspnetUserId(), navigationProperties).ConfigureAwait(false);
        }

        protected UserType GetLoggedUserType()
        {
            return (UserType)((CustomIdentity)HttpContext.User.Identity).UserType;
        }

        protected string GetMyAspnetUserId()
        {
            return ((CustomIdentity)HttpContext.User.Identity).AspNetUserId;
        }

        protected bool IsOfUserType(UserType userType)
        {
            return GetLoggedUserType() == userType;
        }

        protected CustomIdentity GetIdentity()
        {
            return ((CustomIdentity)HttpContext.User.Identity);
        }

        protected string HashPassword(string password)
        {
            return UserManager.PasswordHasher.HashPassword(password);
        }

        protected ApplicationSignInManager SignInManager
        {
            get { return mSignInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { mSignInManager = value; }
        }

        protected ApplicationUserManager UserManager
        {
            get { return mUserManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { mUserManager = value; }
        }

    }
}