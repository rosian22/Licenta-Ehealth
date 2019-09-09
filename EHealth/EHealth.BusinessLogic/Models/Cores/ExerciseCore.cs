using DataLayer.EHealth;
using DataLayer.EHealth.Extensions;
using DataLayer.EHealth.Repositories;
using EHealth.BusinessLogic.Enums;
using EHealth.BusinessLogic.Helpers;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http.Results;
using UpWorky.BusinessLogic.ModelCore.Base;

namespace EHealth.BusinessLogic.Models.Cores
{
    public class ExerciseCore : BaseSinglePkCore<ExerciseRepository, Exercise>
    {
        public static ExercisesReturnedModel GetExerciseData(ExerciseViewModel model)
        {
            Expression<Func<Exercise, bool>> expression = t => t.Status == (int)EntityStatus.ACTIVE;

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                expression = expression.AndAlso(t => t.Name.Contains(model.Name));
            }

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                expression = expression.AndAlso(t => t.Description.Contains(model.Description));
            }

            var data = GetListEF(expression, new[] { nameof(Exercise.MuscleGroup) });
            if (data == null)
            {
                return null;
            }

            foreach (var item in data)
            {
                item.MuscleGroup.Exercises = null;
            }

            var upperExercises = new List<Exercise>();
            var middleExercises = new List<Exercise>();
            var lowerExercises = new List<Exercise>();

            upperExercises = data.Where(t => t.MuscleGroup.MuscleSectionStatus == (int)MuscleSectionEnum.UPPER).ToList();
            middleExercises = data.Where(t => t.MuscleGroup.MuscleSectionStatus == (int)MuscleSectionEnum.MDDLE).ToList();
            lowerExercises = data.Where(t => t.MuscleGroup.MuscleSectionStatus == (int)MuscleSectionEnum.LOWER).ToList();

            var returnedModel = new ExercisesReturnedModel
            {
                LowerExercises = lowerExercises,
                MiddleExercises = middleExercises,
                UpperExercises = upperExercises
            };

            return returnedModel;
        }

        public static Response UpdateExercises(CreateExerciseViewModel model)
        {

            if (model.Id == Guid.Empty)
            {
                return null;
            }

            using (var unitOfWork = RepoUnitOfWork.New())
            {
                var exerciseRepo = unitOfWork.TrackingRepository<ExerciseRepository>();
                var exercises = exerciseRepo.Get(model.Id);

                if (exercises == null)
                {
                    return null;
                }

                exercises.MuscleGroupId = model.MuscleGroupId;
                exercises.PictureUrl = model.PictureUrl;
                exercises.Description = model.Description;
                exercises.VideoUrl = model.VideoUrl;
                exercises.Name = model.Name;

                var updatedExercise = exerciseRepo.Update(exercises);

                if (updatedExercise == null)
                {
                    return null;
                }

                unitOfWork.CommitTransaction();
                return ResponseFactory.SuccessResponse;
            }
        }

        public static Response DeleteExercise(Guid Id)
        {
            var exercise = Get(Id);
            if (exercise == null)
            {
                return null;
            }

            exercise.Status = (int)EntityStatus.DELETED;

            var updatedResponse = Update(exercise);
            if (updatedResponse == null)
            {
                return null;
            }

            return ResponseFactory.SuccessResponse;
        }

        public static Response CreateExercises(CreateExerciseViewModel model)
        {

            var tobeCreatedExercise = new Exercise
            {
                Id = Guid.NewGuid(),
                PictureUrl = model.PictureUrl,
                Description = model.Description,
                VideoUrl = model.VideoUrl,
                MuscleGroupId = model.MuscleGroupId,
                Name = model.Name,
                Status = (int)EntityStatus.ACTIVE,
            };

            var createdExecise = Create(tobeCreatedExercise);
            if (createdExecise == null)
            {
                return null;
            }

            return ResponseFactory.SuccessResponse;
        }

        public static CreateExerciseViewModel GetExerciseDetails(Guid exerciseId)
        {
            var exercise = Get(exerciseId, new[] { nameof(Exercise.MuscleGroup) });
            if (exercise == null)
            {
                return null;
            }

            var returnedModel = new CreateExerciseViewModel()
            {
                Id = exercise.Id,
                Description = exercise.Description,
                MuscleGroupId = exercise.MuscleGroupId,
                PictureUrl = exercise.PictureUrl,
                SectionId = exercise.MuscleGroup.MuscleSectionStatus
            };

            return returnedModel;
        }
    }
}
