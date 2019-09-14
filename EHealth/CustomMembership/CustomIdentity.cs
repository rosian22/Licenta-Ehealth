using EHealth.BusinessLogic.Models;
using System;
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

        public Guid Id { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string FullName { get; set; }

        public int NumberOfMealsPerDay { get; set; }

        public int NumberOfWorkoutsPerDay { get; set; }

        public string BirthDay { get; set; }

        #endregion

    }
}