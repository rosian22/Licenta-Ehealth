using CustomMembership;
using EHealth.BusinessLogic.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
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

        private static async Task SetPrincipal(AuthorizationContext filterContext, string validationToken)
        {
            await SetIdentity(filterContext, validationToken).ConfigureAwait(false);
        }

        private static async Task SetIdentity(AuthorizationContext filterContext, string validationToken)
        {
            var user = await AspNetUserCore.GetAsync(validationToken).ConfigureAwait(false);
            if (user == null)
            {
                return;
            }

            var identity = new CustomIdentity();

            identity.AspNetUserId = validationToken;
            identity.Username = user.Email;
            identity.Name = user.;
            identity.Status = user.AspNetUser.Status;
            identity.Id = user.Id;
            identity.ProfileImageUrl = null;
            identity.NotificationsCount = NotificationCore.Count(n => n.TriggeredByUserId == identity.Id);
            identity.WhiteLabelId = whitelabel.Id;
            identity.UserType = user.UserType;
            identity.FullName = user.FullName;

            SetIdentity(filterContext, identity, user.AspNetUser);
        }

        private static void SetIdentity(AuthorizationContext filterContext, CustomIdentity identity, DataLayer.AspNetUser user)
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