using DataLayer.EHealth;
using EHealth.BusinessLogic.Models.Cores;
using EHealth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
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

    }
}