using DataLayer.EHealth;
using DataLayer.EHealth.Repositories;
using EHealth.BusinessLogic.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public class MealCore : BaseSinglePkCore<MealRepository, Recipe>
    {
        public static Response CreateMeal(CreateMealViewModel model)
        {
            using (var unitOfWork = RepoUnitOfWork.New())
            {
                var foodRepo = unitOfWork.Repository<FoodRepository>();
                var mealRepo = unitOfWork.Repository<MealRepository>();

                var meal = new Recipe
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    PictureUrl = model.PictureUrl,
                };

                double? caloriValue = 0;

                var listOfFoodsAssignments = new List<RecipeFoodAssignment>();
                if (model.SelectedFoods != null)
                {
                    foreach (var item in model.SelectedFoods)
                    {
                        var food = foodRepo.Get(item.Id);
                        if (food == null)
                        {
                            unitOfWork.RollbackTransaction();
                            return ResponseFactory.ErrorReponse;
                        }

                        caloriValue = caloriValue + (item.Quantity * food.Calories) / food.Grams;

                        var foodItems = new RecipeFoodAssignment
                        {
                            FoodId = item.Id,
                            RecipeId = meal.Id,
                            Quantity = item.Quantity
                        };

                        listOfFoodsAssignments.Add(foodItems);
                    }
                }
                meal.Calories = caloriValue ?? caloriValue.Value;
                meal.RecipeFoodAssignments = listOfFoodsAssignments;

                var mealCreation = mealRepo.Create(meal);
                if (mealCreation == null)
                {
                    unitOfWork.RollbackTransaction();
                    return ResponseFactory.ErrorReponse;
                }

                unitOfWork.CommitTransaction();
                return ResponseFactory.SuccessResponse;
            }
        }

        public static Response UpdateMeal(CreateMealViewModel model)
        {
            using (var mealRepo = RepoUnitOfWork.CreateTrackingRepository<MealRepository>())
            using (var foodRepo = RepoUnitOfWork.CreateTrackingRepository<FoodRepository>())

            {
                var currentMeal = mealRepo.Get(model.Id);

                currentMeal.Name = model.Name;
                currentMeal.PictureUrl = model.PictureUrl;
                currentMeal.Description = model.Description;

                double? caloriValue = 0;

                var listOfFoodsAssignments = new List<RecipeFoodAssignment>();
                if (model.SelectedFoods != null)
                {
                    foreach (var item in model.SelectedFoods)
                    {
                        var food = foodRepo.Get(item.Id);
                        if (food == null)
                        {
                            return ResponseFactory.ErrorReponse;
                        }

                        caloriValue = caloriValue + (item.Quantity * food.Calories) / food.Grams;

                        var foodItems = new RecipeFoodAssignment
                        {
                            FoodId = item.Id,
                            RecipeId = currentMeal.Id,
                            Quantity = item.Quantity
                        };

                        listOfFoodsAssignments.Add(foodItems);
                    }
                }

                currentMeal.RecipeFoodAssignments = listOfFoodsAssignments;
                currentMeal.Calories = caloriValue ?? caloriValue.Value;

                var updatedMeal = mealRepo.Update(currentMeal);
                if (updatedMeal == null)
                {
                    return ResponseFactory.ErrorReponse;
                }

                return ResponseFactory.SuccessResponse;
            }
        }

    }
}
