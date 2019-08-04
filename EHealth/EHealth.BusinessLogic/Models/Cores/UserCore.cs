using DataLayer.EHealth;
using DataLayer.EHealth.Repositories;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public partial class UserCore : BaseSinglePkCore<UserRepository, User>
    {
    }
}