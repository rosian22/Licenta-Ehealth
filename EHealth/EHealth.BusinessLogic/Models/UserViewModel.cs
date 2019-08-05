using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class UserViewModel
    {
        public string AspNetUserId { get; set; }

        public Guid UserId { get; set; }

        public string ProfilePictureUrl { get; set; }

        public float BodyWeight { get; set; }

        public int CaloriesBurned { get; set; }

        public int GoalsAchived { get; set; }

        public int Achivements { get; set; }

        public int DailyGoal { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public int DailyMin { get; set; }

        public int WeeklyMin { get; set; }

        public int MonthlyMin { get; set; }

    }
}
