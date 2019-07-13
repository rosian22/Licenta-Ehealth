using System;

namespace EHealth.BusinessLogic.Models
{
    public class CreateUserModel
    {
        public Guid? AspNetUserId { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhonePrefix { get; set; }

        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; set; }
        public Guid CreatedBy { get; set; }
        public string ProfilePictureUrl { get; set; }
        public long PictureVersion { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
