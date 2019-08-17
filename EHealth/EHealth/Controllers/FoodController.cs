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
    public class FoodController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetFoodItems(string term)
        {
            Expression<Func<Food, bool>> expression = t => t.Status == (int)EntityStatus.ACTIVE;

            if (!string.IsNullOrWhiteSpace(term))
            {
                expression = t => t.Status == (int)EntityStatus.ACTIVE && t.Name.Contains(term.Trim());
            }

            var foods = await FoodCore.GetListAsync(expression).ConfigureAwait(false);
            if (foods == null)
            {
                return Json(new List<Food>());
            }

            return Json(foods, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(CreateFoodViewModel model)
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

        public Response Create(CreateFoodViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return null;
            }

            var file = Request.Files["Photo"];
            var url = AzureHelper.Upload(file, "Photo", Guid.NewGuid());

            var createdFood = new Food()
            {
                Name = model.Name,
                Carbohidrates = model.Carbohydrates,
                Description = model.Description,
                Fats = model.Fats,
                Fiber = model.Fibre,
                Proteins = model.Proteins,
                Sugar = model.Sugar,
                Grams = model.Grams,
                Calories = model.Calories,
                PictureUrl = url,
                Status = (int)EntityStatus.ACTIVE
            };

            var foodCreationResponse = FoodCore.Create(createdFood);
            if (foodCreationResponse == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.SuccessResponse;
        }

        public Response Update(CreateFoodViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return null;
            }

            var foodItem = FoodCore.Get(model.Id);
            if (foodItem == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            if (!string.IsNullOrWhiteSpace(model.Photo) && model.Photo != "undefined")
            {
                var file = Request.Files["Photo"];
                var url = AzureHelper.Upload(file, "Photo", Guid.NewGuid());
                foodItem.PictureUrl = url;
            }

            foodItem.Name = model.Name;
            foodItem.Carbohidrates = model.Carbohydrates;
            foodItem.Description = model.Description;
            foodItem.Fats = model.Fats;
            foodItem.Fiber = model.Fibre;
            foodItem.Proteins = model.Proteins;
            foodItem.Sugar = model.Sugar;
            foodItem.Grams = model.Grams;
            foodItem.Calories = model.Calories;
            foodItem.Status = (int)EntityStatus.ACTIVE;


            var foodCreationResponse = FoodCore.Update(foodItem);
            if (foodCreationResponse == null)
            {
                return ResponseFactory.ErrorReponse;
            }

            return ResponseFactory.SuccessResponse;
        }

        public JsonResult Delete(Guid foodId)
        {
            if (foodId == Guid.Empty)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            try
            {
                FoodCore.Delete(foodId);
            }
            catch (Exception ex)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.SuccessResponse, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetFoodDetails(Guid foodId)
        {
            if (foodId == Guid.Empty)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            var foodDetails = FoodCore.GetFoodDetails(foodId);
            if (foodDetails == null)
            {
                return Json(ResponseFactory.ErrorReponse);
            }

            return Json(ResponseFactory.Success((int)ResponseCode.Success, foodDetails), JsonRequestBehavior.AllowGet);
        }
    }
}