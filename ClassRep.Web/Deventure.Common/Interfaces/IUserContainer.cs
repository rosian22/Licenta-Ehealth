using System;

namespace Deventure.Common.Interfaces
{
    public interface IUserContainer
    {
        string Email { get; set; }
        string AccessToken { get; set; }
        DateTime ExpirationDate { get; set; }
    }
}