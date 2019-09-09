using EHealth.BusinessLogic.Models.Cores;
using EHealth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}