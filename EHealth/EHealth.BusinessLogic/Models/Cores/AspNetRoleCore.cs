using DataLayer.EHealth;
using DataLayer.EHealth.Repositories;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{

    public enum HandlingAction
    {
        REMOVE = 0,
        ADD = 1,
    }

    public class AspNetRoleCore : BaseCore<AspNetRoleRepository, AspNetRole>
    {

        internal static async Task<Response> ManageUserRoleAsync(AspNetUser aspNetUser, string roleId, RepoUnitOfWork unitOfWork, int handlingAction = (int)HandlingAction.ADD)
        {
            var aspNetUserRoleRepository = unitOfWork.TrackingRepository<AspNetRoleRepository>();

            var aspNetRole = await aspNetUserRoleRepository.GetAsync(roleId).ConfigureAwait(false);
            if (aspNetRole == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            if (handlingAction == (int)HandlingAction.ADD)
            {
                if (aspNetUser.AspNetRoles.Any(role => role.Id == roleId))
                {
                    return ResponseFactory.SuccessResponse;
                }
                aspNetUser.AspNetRoles.Add(aspNetRole);
            }
            else if (handlingAction == (int)HandlingAction.REMOVE)
            {
                if (aspNetUser.AspNetRoles.All(role => role.Id != roleId))
                {
                    return ResponseFactory.SuccessResponse;
                }
                aspNetUser.AspNetRoles.Remove(aspNetRole);
            }

            var aspNetUserRepository = unitOfWork.TrackingRepository<AspNetUserRepository>();
            var updatedAspNetUser = await aspNetUserRepository.UpdateAsync(aspNetUser).ConfigureAwait(false);
            if (updatedAspNetUser == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.SuccessResponse;
        }

    }
}
