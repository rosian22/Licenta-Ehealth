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
    }
}
