using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Workflow;
using EHealth.BusinessLogic.Workflow.Interfaces;
using EHealth.DataLayer.Interfaces;
using EHealth.DataLayer.Repositories;

namespace UpWorky.BusinessLogic.ModelCore.Base
{
    public abstract class BaseCore<TRepo, TEntity>
        where TRepo : BaseRepository<TEntity>, new()
        where TEntity : class, IDataAccessObject, new()
    {
        #region Singular structure result methods

        public static async Task<int> CountAsync()
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.CountAsync().ConfigureAwait(false);
            }
        }

        public static async Task<int> CountAsync(Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.CountAsync(@where).ConfigureAwait(false);
            }
        }

        public static int Count(Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return repository.Count(@where);
            }
        }

        #region Sum

        public async Task<int> SumAsync(Expression<Func<TEntity, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> SumAsync(Expression<Func<TEntity, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> SumAsync(Expression<Func<TEntity, int>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> SumAsync(Expression<Func<TEntity, int?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> SumAsync(Expression<Func<TEntity, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> SumAsync(Expression<Func<TEntity, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> SumAsync(Expression<Func<TEntity, float>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> SumAsync(Expression<Func<TEntity, float?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> SumAsync(Expression<Func<TEntity, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> SumAsync(Expression<Func<TEntity, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> SumAsync(Expression<Func<TEntity, double>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> SumAsync(Expression<Func<TEntity, double?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> SumAsync(Expression<Func<TEntity, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> SumAsync(Expression<Func<TEntity, decimal?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.SumAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #region Min

        public async Task<int> MinAsync(Expression<Func<TEntity, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> MinAsync(Expression<Func<TEntity, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> MinAsync(Expression<Func<TEntity, int>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> MinAsync(Expression<Func<TEntity, int?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> MinAsync(Expression<Func<TEntity, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> MinAsync(Expression<Func<TEntity, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> MinAsync(Expression<Func<TEntity, float>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> MinAsync(Expression<Func<TEntity, float?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> MinAsync(Expression<Func<TEntity, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> MinAsync(Expression<Func<TEntity, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> MinAsync(Expression<Func<TEntity, double>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> MinAsync(Expression<Func<TEntity, double?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MinAsync(Expression<Func<TEntity, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MinAsync(Expression<Func<TEntity, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MinAsync(Expression<Func<TEntity, decimal>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MinAsync(Expression<Func<TEntity, decimal?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MinAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #region Max

        public async Task<int> MaxAsync(Expression<Func<TEntity, int>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int?> MaxAsync(Expression<Func<TEntity, int?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<int> MaxAsync(Expression<Func<TEntity, int>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<int?> MaxAsync(Expression<Func<TEntity, int?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float> MaxAsync(Expression<Func<TEntity, float>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float?> MaxAsync(Expression<Func<TEntity, float?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<float> MaxAsync(Expression<Func<TEntity, float>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<float?> MaxAsync(Expression<Func<TEntity, float?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double> MaxAsync(Expression<Func<TEntity, double>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double?> MaxAsync(Expression<Func<TEntity, double?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<double> MaxAsync(Expression<Func<TEntity, double>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<double?> MaxAsync(Expression<Func<TEntity, double?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MaxAsync(Expression<Func<TEntity, decimal>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MaxAsync(Expression<Func<TEntity, decimal?>> selector)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector).ConfigureAwait(false);
            }
        }

        public async Task<decimal> MaxAsync(Expression<Func<TEntity, decimal>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        public async Task<decimal?> MaxAsync(Expression<Func<TEntity, decimal?>> selector, Expression<Func<TEntity, bool>> where)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return await repository.MaxAsync(selector, @where).ConfigureAwait(false);
            }
        }

        #endregion

        #endregion

        public static IEnumerable<TEntity> ExecuteStoredProcedureList(IStoreProcedure storedProcedure)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                return repository.ExecuteStoredProcedureList<TEntity>(storedProcedure);
            }
        }

        public static void ExecuteStoredProcedure(IStoreProcedure storedProcedure)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                repository.ExecuteStoredProcedure(storedProcedure);
            }
        }

        #region CRUD

        public static async Task<IList<TEntity>> GetAllAsync(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                return entities;
            }
        }

        public static IList<TEntity> GetAll(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetAll(navigationProperties);
                return entities;
            }
        }

        public static async Task<IList<TEntity>> GetAllEFAsync(IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                return entities;
            }
        }

        public static async Task<IList<TEntity>> GetAllAsync<TKey>(IList<string> navigationProperties = null, Func<TEntity, TKey> orderByExpression = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync(navigationProperties).ConfigureAwait(false);
                if (orderByExpression != null)
                {
                    return entities.OrderBy(orderByExpression).ToList();
                }
                return entities;
            }
        }

        public static IConfigurableQuery<TEntity> GetAllQuery(IList<string> navigationProperties = null)
        {
            var repository = RepoUnitOfWork.CreateRepository<TRepo>();
            var query = repository.GetAllQuery(navigationProperties);

            return new ConfigurableQuery<TEntity>(repository.Context, query);
        }


        public static IList<TEntity> GetListEF(Expression<Func<TEntity, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = repository.GetList(@where, navigationProperties);
                return entities;
            }
        }


        public static async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateRepository<TRepo>())
            {
                var entities = await repository.GetListAsync(@where, navigationProperties).ConfigureAwait(false);

                return entities;
            }
        }

        public static IQueryable<TEntity> GetListQuery(Expression<Func<TEntity, bool>> where, IList<string> navigationProperties = null)
        {
            var repository = RepoUnitOfWork.CreateRepository<TRepo>();
            var query = repository.GetListQuery(@where, navigationProperties);
            return query;
        }

        public static async Task<TEntity> CreateAsync(TEntity model, bool refreshFromDb = false, TRepo Trepository = null, IList<string> navigationProperties = null)
        {
            if (Trepository == null)
            {
                Trepository = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }

            var entity = await Trepository.CreateAsync(model, refreshFromDb, navigationProperties).ConfigureAwait(false);

            return entity;

        }

        public static TEntity Create(TEntity model, bool refreshFromDb = false, TRepo Trepository = null, IList<string> navigationProperties = null)
        {
            if (Trepository == null)
            {
                Trepository = RepoUnitOfWork.CreateTrackingRepository<TRepo>();
            }

            var entity = Trepository.Create(model, refreshFromDb, navigationProperties);

            return entity;

        }

        public static async Task<IList<TEntity>> CreateAsync(IList<TEntity> modelCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {

                var entityCollection = await repository.CreateAsync(modelCollection, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entityCollection;
            }
        }

        public static IList<TEntity> Create(IList<TEntity> modelCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {

                var entityCollection = repository.Create(modelCollection, refreshFromDb, navigationProperties);

                return entityCollection;
            }
        }

        public static async Task<TEntity> UpdateAsync(TEntity model, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entity = await repository.UpdateAsync(model, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entity;
            }
        }

        public static TEntity Update(TEntity model, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entity = repository.Update(model, refreshFromDb, navigationProperties);
                return entity;
            }
        }

        public static async Task<IList<TEntity>> UpdateAsync(IList<TEntity> modelCollection, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entityCollection = await repository.UpdateAsync(modelCollection, refreshFromDb, navigationProperties).ConfigureAwait(false);

                return entityCollection;
            }
        }

        public static async Task<bool> DeleteAsync(TEntity model)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                return await repository.DeleteAsync(model).ConfigureAwait(false);
            }
        }

        public static async Task<bool> DeleteAsync(IList<TEntity> modelCollection)
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                return await repository.DeleteAsync(modelCollection).ConfigureAwait(false);
            }
        }

        public static async Task<Response> DeleteAllAsync()
        {
            using (var repository = RepoUnitOfWork.CreateTrackingRepository<TRepo>())
            {
                var entities = await repository.GetAllAsync().ConfigureAwait(false);

                await repository.DeleteAsync(entities).ConfigureAwait(false);

                entities = await repository.GetAllAsync().ConfigureAwait(false);
                if (entities != null && entities.Any())
                {
                    return ResponseFactory.ErrorReponse;
                }

                return ResponseFactory.SuccessResponse;
            }
        }

        #endregion
    }
}