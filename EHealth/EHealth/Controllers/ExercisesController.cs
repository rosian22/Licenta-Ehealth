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
            return View("~/Views/Exercises/Index.cshtml");
        }

        public JsonResult GetExerciseData(ExerciseViewModel model)
        {
            var exercises = ExerciseCore.GetExerciseData(model);
            if (exercises == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.Success((int)ResponseCode.Success, exercises), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(CreateExerciseViewModel model)
        {
            var response = ResponseFactory.ErrorReponse;
            if (model.Id == Guid.Empty)
            {
                response = Create(model);
            }
            else
            {
                response = Update(model);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public Response Update(CreateExerciseViewModel model)
        {
            var savedResponse = ExerciseCore.UpdateExercises(model);
            if (savedResponse == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.SuccessResponse;
        }

        public Response Create(CreateExerciseViewModel model)
        {

            var file = Request.Files["PictureUrl"];
            var url = AzureHelper.Upload(file, "PictureUrl", Guid.NewGuid());
            model.PictureUrl = url;

            var creationResponse = ExerciseCore.CreateExercises(model);
            if (creationResponse == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.SuccessResponse;
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

        public JsonResult GetFoodDetails(Guid exerciseId)
        {

            if (exerciseId == Guid.Empty)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            var exercisesDetails = ExerciseCore.GetExerciseDetails(exerciseId);
            if (exercisesDetails == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.Success((int)ResponseCode.Success, exercisesDetails), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMuscleGroups()
        {
            var muscleGroups = MuscleGroupCore.GetAll();
            if(muscleGroups == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.Success((int) ResponseCode.Success, muscleGroups), JsonRequestBehavior.AllowGet);
        }

    }
}