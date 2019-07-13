using System;
using Deventure.Common.Interfaces;

namespace Deventure.Common
{
    public class UserCredentialsContainer : IUserContainer
    {
        public string Email { get; set; }

        public string AccessToken { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}