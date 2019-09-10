using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class MealViewModel
    {
        public Guid Id { get; set; }

        public string PictureUrl { get; set; }

        public string Calories { get; set; }

        public string Name { get; set; }

    }
}
