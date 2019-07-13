using System;
namespace Deventure.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public Guid WhitelabelId { get; set; }

        public bool IsInTalentPool { get; set; }

        public string iOSDeviceToken { get; set; }

        public string DeviceId { get; set; }

        public int NotesCount { get; set; }

        public string Address{ get; set; }
       
    }
}
