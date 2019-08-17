using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class CreateFoodViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Carbohydrates { get; set; }

        public double Sugar { get; set; }

        public double Fibre { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public int Grams { get; set; }

        public double Calories { get; set; }

        public string Photo { get; set; }
    }
}
