using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EHealth.DataLayer.Interfaces;

namespace EHealth.DataLayer.Repositories
{
    public abstract class BaseSinglePkRepository<T> : BaseRepository<T>
        where T : class, ISinglePkDataAccessObject, new()
    {
        public async Task<T> GetAsync(Guid id, IList<string> navigationProperties = null)
        {
            return await GetSingleAsync(entity => entity.Id == id, navigationProperties).ConfigureAwait(false);
        }

        public T Get(Guid id, IList<string> navigationProperties = null)
        {
            return GetSingle(entity => entity.Id == id, navigationProperties);
        }

        public bool Delete(Guid id)
        {
            var entity = Get(id);
            Remove(entity);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id).ConfigureAwait(false);
            if(!ValidateEntity(entity))
            {
                return false;
            }

            await RemoveAsync(entity).ConfigureAwait(false);

            return true;
        }

       

        #region Overrides

        public override Task<T> CreateAsync(T entity, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            return base.CreateAsync(entity, refreshFromDb, navigationProperties);
        }

        public override Task<IList<T>> CreateAsync(IList<T> entities, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            foreach (var item in entities)
            {
                if(item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
            }

            return base.CreateAsync(entities, refreshFromDb, navigationProperties);
        }


        public override T Create(T entity, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            return base.Create(entity, refreshFromDb, navigationProperties);
        }

        public override IList<T> Create(IList<T> entities, bool refreshFromDb = false, IList<string> navigationProperties = null)
        {
            Parallel.ForEach(entities.Where(entity => entity.Id == Guid.Empty), entity => { entity.Id = Guid.NewGuid(); });

            return base.Create(entities, refreshFromDb, navigationProperties);
        }

        protected override async Task<T> FetchFromDbAsync(T entity, IList<string> navigationProperties = null)
        {
            return await GetAsync(entity.Id, navigationProperties).ConfigureAwait(false);
        }

        protected override T FetchFromDb(T entity, IList<string> navigationProperties = null)
        {
            return Get(entity.Id, navigationProperties);
        }

        protected override bool ValidateEntity(T entity)
        {
            if (entity != null && entity.Id != Guid.Empty)
            {
                return true;
            }

            //LogHelper.LogException<BaseDataRepository>("Invalid entity: null or empty primary keys");
            return false;
        }


        #endregion
    }
}