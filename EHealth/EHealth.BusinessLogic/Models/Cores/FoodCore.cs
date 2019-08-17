using DataLayer.EHealth;
using DataLayer.EHealth.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public class FoodCore : BaseSinglePkCore<FoodRepository, Food>
    {
        public static CreateFoodViewModel GetFoodDetails(Guid foodId)
        {
            var food = Get(foodId);
            if(food == null)
            {
                return null;
            }

            var returnedModel = new CreateFoodViewModel()
            {
                Id = food.Id,
                Calories = food.Calories.Value,
                Carbohydrates = food.Carbohidrates.Value,
                Description = food.Description,
                Fats = food.Fats.Value,
                Fibre = food.Fiber.Value,
                Grams = food.Grams,
                Name = food.Name,
                Photo = food.PictureUrl,
                Proteins = food.Proteins.Value,
                Sugar = food.Sugar.Value
            };

            return returnedModel;
        }
    }
}
