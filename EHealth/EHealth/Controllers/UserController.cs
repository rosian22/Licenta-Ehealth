using datalayer = DataLayer.EHealth;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace EHealth.Controllers
{
    public class UserController : GenericBaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View(GetUsers());
        }

        public IList<datalayer.User> GetUsers()
        {
            var navProp = new[] {
                nameof(datalayer.User.AspNetUser)
            };

            var users = UserCore.GetListEF(t => t.AspNetUser.UserType != (int)UserType.ADMIN, navProp);
            if (users == null)
            {
                users = new List<datalayer.User>();
            }

            return users;
        }

        public async Task<JsonResult> GetUserData()
        {
            var identity = GetIdentity();

            var model = await UserCore.GetUserData(identity.AspNetUserId).ConfigureAwait(false);
            if (model == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.CreateResponse(true, (int)ResponseCode.Success, model));
        }

        public JsonResult Deactivate(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            var user = UserCore.Get(userId, new[] { nameof(datalayer.User.AspNetUser) });
            if (user == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            user.AspNetUser.Status = -1;

            var updatedUser = AspNetUserCore.Update(user.AspNetUser);
            if (updatedUser == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse);
        }

        public JsonResult Activate(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return Json(ResponseFactory.ErrorReponse);

            }

            var user = UserCore.Get(userId, new[] { nameof(datalayer.User.AspNetUser) });
            if (user == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            user.AspNetUser.Status = 0;

            var updatedUser = AspNetUserCore.Update(user.AspNetUser);
            if (updatedUser == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse);
        }

    }
}