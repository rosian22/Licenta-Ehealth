using DataLayer.EHealth;
using DataLayer.EHealth.Repositories;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public class UserCore : BaseSinglePkCore<UserRepository, User>
    {
        public static async Task<UserViewModel> GetUserData(string aspNetUserId)
        {
            if (string.IsNullOrWhiteSpace(aspNetUserId) || aspNetUserId == Guid.Empty.ToString())
            {
                return null;
            }

            var userRepo = RepoUnitOfWork.CreateTrackingRepository<UserRepository>();

            var user = await userRepo.GetSingleAsync(usr => usr.AspNetUserId == aspNetUserId, new[] {
                            nameof(User.AspNetUser)
                       }).ConfigureAwait(false);

            var model = new UserViewModel()
            {
                AspNetUserId = user.AspNetUserId,
                UserId = user.Id,
                ProfilePictureUrl = user.ProfilePictureUrl,
                BodyWeight = 0,
                CaloriesBurned = 0,
                GoalsAchived = 0,
                Achivements = 0,
                DailyGoal = 0,
                Email = user.AspNetUser.Email,
                FullName = user.FullName,
                BirthDay = user.BirthDay ?? user.BirthDay.Value,
                DailyMin = 0,
                WeeklyMin = 0,
                MonthlyMin = 0,
            };

            return model;
        }
    }
}