using EHealth.BusinessLogic.Models;
using System.Security.Principal;

namespace CustomMembership
{
    public class CustomIdentity : IIdentity
    {
        #region from interface

        public string Name => IsAuthenticated ? Username : null;

        public string AuthenticationType => "Custom";

        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(AspNetUserId);

        public bool IsUserActive => Status == (int)UserStatus.ACTIVE;

        #endregion

        #region custom fields

        public string AspNetUserId { get; set; }

        public string Username { get; set; }

        public int Status { get; set; }

        public int UserType { get; set; }

        #endregion

    }
}