using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EHealth.DataLayer.Repositories;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Interfaces;
using EHealth.BusinessLogic.Models;

namespace UpWorky.BusinessLogic.ModelCore.Base
{
    public abstract class BaseSinglePkCore<TRepo, TEntity> : BaseCore<TRepo, TEntity>
        where TRepo : BaseSinglePkRepository<TEntity>, new()
        where TEntity : class, ISinglePkDataAccessObject, new()
    {
        public static async Task<TEntity> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAsync(id, navigationProperties).ConfigureAwait(false);
                return entities;
            }
        }

        public static TEntity Get(Guid id, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.Get(id, navigationProperties);
                return entities;
            }
        }

        public static TEntity GetSingle(Expression<Func<TEntity, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entity = repository.GetSingle(where, navigationProperties);
                return entity;
            }
        }

        public static async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entity = await repository.GetSingleAsync(where, navigationProperties);
                return entity;
            }
        }

        public static async Task<Response> DeleteAsync(Guid id)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var response = ResponseFactory.ErrorReponse;
                var result = await repository.DeleteAsync(id).ConfigureAwait(false);
                if(result)
                {
                    response = ResponseFactory.SuccessResponse;
                }
                return response;
            }
        }

        public static void Delete(Guid id)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                repository.Delete(id);
            }
        }

        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection)
           where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListAsync(entity => idCollection.Any(id => id == entity.Id)).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();
            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
            }).ToList();

            var createdEntities = await repository.CreateAsync(newEntities).ConfigureAwait(false);
            resultList.AddRange(createdEntities);

            return resultList;
        }

        public static IList<T> HandleList<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection, IList<string> navigationProperties = null)
              where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = repository.GetList(entity => idCollection.Any(id => id == entity.Id), navigationProperties);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();

            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
            }).ToList();

            var createdEntities = repository.Create(newEntities);
            resultList.AddRange(createdEntities);

            return resultList;
        }

        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkRepository<T> repository, IList<Guid> idCollection,
            Func<T, bool> prepareFunc = null, IList<string> navigationProperties = null)
            where T : class, ISinglePkDataAccessObject, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListAsync(
                            entity => idCollection.Any(id => id == entity.Id), navigationProperties).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = idCollection.Where(id => existingEntities.All(entity => entity.Id != id)).ToList();
            if (diff.Count == 0)
            {
                return resultList;
            }
            var newEntities = diff.Select(id => new T
            {
                Id = id
            }).ToList();

            if (prepareFunc != null)
            {
                var finalList = new List<T>();
                foreach (var entity in newEntities)
                {
                    if (prepareFunc(entity))
                    {
                        finalList.Add(entity);
                    }
                }

                newEntities = finalList;
            }

            var createdEntities = await repository.CreateAsync(newEntities).ConfigureAwait(false);
            resultList.AddRange(createdEntities);

            return resultList;
        }
    }
}