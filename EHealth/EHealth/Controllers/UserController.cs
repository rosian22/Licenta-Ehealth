using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EHealth.Controllers
{
    public class UserController : GenericBaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
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

    }
}