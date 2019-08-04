using CustomMembership;
using DataLayer.EHealth;
using EHealth.BusinessLogic.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EHealth.Helpers
{
    public class GlobalIdentityInjectorAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        #region Public methods

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                //Extract the forms authentication cookie
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null)
                {
                    return;
                }
                var concatenatedUserData = authTicket.UserData;
                var data = concatenatedUserData.Split(new[]
                {
                    "#"
                }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Count() != 1)
                {
                    return;
                }

                var validationToken = data[0];
                if (validationToken == null)
                {
                }

                 SetPrincipal(filterContext, validationToken);

                FormsAuthentication.RenewTicketIfOld(authTicket);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Private methods

        private static void SetPrincipal(AuthorizationContext filterContext, string validationToken)
        {
            SetIdentity(filterContext, validationToken);
        }

        private static void SetIdentity(AuthorizationContext filterContext, string validationToken)
        {
            var user = UserCore.GetSingle(usr => usr.AspNetUserId == validationToken, new[] { nameof(User.AspNetUser)});
            if (user == null)
            {
                return;
            }

            var identity = new CustomIdentity
            {
                AspNetUserId = validationToken,
                Username = user.AspNetUser.Email,
                Status = user.AspNetUser.Status ?? user.AspNetUser.Status.Value,
                Id = user.Id,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserType = user.AspNetUser.UserType ?? user.AspNetUser.UserType.Value,
                FullName = user.FullName
            };

            SetIdentity(filterContext, identity, user.AspNetUser);
        }

        private static void SetIdentity(AuthorizationContext filterContext, CustomIdentity identity, AspNetUser user)
        {
            var newUser = new CustomPrincipal(identity)
            {
                RoleIds = user.AspNetRoles.Select(role => role.Id).ToList(),
            };

            filterContext.HttpContext.User = newUser;
        }

     

        #endregion
    }
}