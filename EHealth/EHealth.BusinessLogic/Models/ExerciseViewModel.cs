﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class ExerciseViewModel
    {
        public Dictionary<string, string> ActiveSectionGroupPaire { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
