using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealth.BusinessLogic.Models
{
    public class ExerciseViewModel
    {
        public Guid Id { get; set; }

        public Guid MuscleGroupId { get; set; }

        public string PictureUrl { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

    }
}
