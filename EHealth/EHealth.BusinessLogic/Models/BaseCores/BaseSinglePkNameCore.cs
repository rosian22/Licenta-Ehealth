using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHealth.BusinessLogic.Workflow;
using EHealth.DataLayer.Interfaces;
using EHealth.DataLayer.Repositories;

namespace UpWorky.BusinessLogic.ModelCore.Base
{
    public class BaseSinglePkNameCore<TRepo, TEntity> : BaseSinglePkCore<TRepo, TEntity>
        where TRepo : BaseSinglePkRepository<TEntity>, new()
        where TEntity : class, IDataAccessObjectWithName, new()
    {
        public static async Task<IList<T>> HandleListAsync<T>(BaseSinglePkNameRepository<T> repository, IList<string> namesCollection, Func<T, bool> prepareFunc = null,
            IList<string> navigationProperties = null)
            where T : class, IDataAccessObjectWithName, new()
        {
            var resultList = new List<T>();

            var existingEntities = await repository.GetListByNames(new List<string>(namesCollection), navigationProperties).ConfigureAwait(false);
            resultList.AddRange(existingEntities);

            var diff = namesCollection.Where(name => existingEntities.All(entity => entity.Name.ToLowerInvariant() != name.ToLowerInvariant())).ToList();
            if (diff.Count == 0)
            {
                return resultList;
            }

            var newEntities = diff.Select(name => new T
            {
                Name = name
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

        //public static async Task<IList<TEntity>> GetAllAsync(IList<string> navigationProperties = null, Func<TEntity, string> orderByExpression = null)
        //{
        //    using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
        //    {
        //        var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
        //        if (orderByExpression == null)
        //        {
        //            orderByExpression = entity => entity.Name;
        //        }
        //        return entities.OrderBy(orderByExpression);
        //    }
        //}
    }
}
