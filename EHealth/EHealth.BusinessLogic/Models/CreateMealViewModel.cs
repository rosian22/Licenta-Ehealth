using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class Meal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
    }

    public class CreateMealViewModel
    {
        public Guid Id { get; set; }
        public string PictureUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SelectedFoodsJson { get; set; }
        public IList<Meal> SelectedFoods { get; set; }
    }
}
