using DataLayer.EHealth;
using EHealth.BusinessLogic.Helpers;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using EHealth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EHealth.Controllers
{
    public class ExercisesController : Controller
    {
        // GET: Exercises
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Update(ExerciseViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            var savedResponse = ExerciseCore.SaveExercises(model);
            if (savedResponse == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Guid Id)
        {
            var deleteResponse = ExerciseCore.DeleteExercise(Id);
            if (deleteResponse == null)

            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(ExerciseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            var creationResponse = ExerciseCore.CreateExercises(model);
            if (creationResponse == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse, JsonRequestBehavior.AllowGet);
        }

    }
}