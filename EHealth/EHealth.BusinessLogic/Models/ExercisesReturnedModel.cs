using DataLayer.EHealth;
using System.Collections.Generic;

namespace EHealth.BusinessLogic.Models
{
    public class ExercisesReturnedModel
    {
        public IList<Exercise> UpperExercises { get; set; }
        public IList<Exercise> MiddleExercises { get; set; }
        public IList<Exercise> LowerExercises { get; set; }
    }
}
