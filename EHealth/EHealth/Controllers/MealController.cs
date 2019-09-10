using EHealth.BusinessLogic.Helpers;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using EHealth.DataLayer.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EHealth.Controllers
{
    public class FoodDropdownItems
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }




    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetFoodList()
        {
            var Foods = FoodCore.GetListEF(t => t.Status == (int)EntityStatus.ACTIVE);
            var returnedFoods = new List<FoodDropdownItems>();

            if (Foods != null && Foods.Count > 0)
            {
                foreach (var item in Foods)
                {
                    returnedFoods.Add(new FoodDropdownItems
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
            }

            return Json(returnedFoods, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(CreateMealViewModel model)
        {
            Response response = null;

            if (!string.IsNullOrWhiteSpace(model.SelectedFoodsJson))
            {
                model.SelectedFoods = new JavaScriptSerializer().Deserialize<IList<Meal>>(model.SelectedFoodsJson);
            }

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

        public JsonResult GetMeals()
        {
            var meals = MealCore.GetAll();
            if (meals == null)
            {
                return Json(ResponseFactory.ErrorReponse, JsonRequestBehavior.AllowGet);
            }

            var returnedModel = new List<MealViewModel>();

            foreach (var item in meals)
            {
                returnedModel.Add(new MealViewModel
                {
                    Id = item.Id,
                    Calories = item.Calories.Value.ToString("0.00"),
                    Name = item.Name,
                    PictureUrl = item.PictureUrl
                });
            }

            return Json(ResponseFactory.Success((int)ResponseCode.Success, returnedModel), JsonRequestBehavior.AllowGet);
        }

        public Response Create(CreateMealViewModel model)
        {
            if (model == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            model.Id = Guid.NewGuid();

            var file = Request.Files["PictureUrl"];
            var url = AzureHelper.Upload(file, "PictureUrl", model.Id);
            model.PictureUrl = url;

            var creationResponse = MealCore.CreateMeal(model);
            if (!ResponseFactory.IsSuccessful(creationResponse))
            {
                var azureResponse = AzureHelper.DeleteFromBlob(model.Id);
            }

            return creationResponse;
        }

        public Response Update(CreateMealViewModel model)
        {
            if (model == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            var deleteOldPictureResponse = AzureHelper.DeleteFromBlob(model.Id);
            if (ResponseFactory.IsSuccessful(deleteOldPictureResponse))
            {
                var file = Request.Files["PictureUrl"];
                var url = AzureHelper.Upload(file, "PictureUrl", model.Id);
                model.PictureUrl = url;
            }

            return MealCore.UpdateMeal(model);
        }



    }
}