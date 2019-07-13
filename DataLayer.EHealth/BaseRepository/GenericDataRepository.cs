using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataLayer.EHealth;
using EHealth.DataLayer.Extensions;
using EHealth.DataLayer.Interfaces;

namespace EHealth.DataLayer.Repositories
{
    public abstract class GenericDataRepository<T> : BaseDataRepository
        where T : class, IDataAccessObject, new()
    {
        private DbSet<T> mDbSet;
        private bool mIsEntityTrackingOn;
        private Func<IList<string>, IQueryable<T>> mQueryGenerator;

        protected GenericDataRepository()
        {
            Context = new Entities();
            IsEntityTrackingOn = false;
        }

        #region Overrides

        public override sealed bool IsEntityTrackingOn
        {
            get { return mIsEntityTrackingOn; }
            set
            {
                mIsEntityTrackingOn = value;

                mQueryGenerator = mIsEntityTrackingOn ? (Func<IList<string>, IQueryable<T>>)GenerateQuery : GenerateNonTrackingQuery;
            }
        }

        public override sealed Entities Context
        {
            get { return base.Context; }
            set
            {
                base.Context = value;

                mDbSet = value.Set<T>();
            }
        }

        #endregion

        #region Public singular structure result methods

        public int Count(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            return dbQuery.Count();
        }

        public async Task<int> CountAsync(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            return await dbQuery.CountAsync().ConfigureAwait(false);
        }

        public int Count(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            try
            {
                var dbQuery = mQueryGenerator.Invoke(navigationProperties).Where(@where);

                return dbQuery.Count();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            try
            {
                var dbQuery = mQueryGenerator.Invoke(navigationProperties).Where(@where);

                return await dbQuery.CountAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
        }

        #region Sum

        public async Task<int> SumAsync(Expression<Func<T, int>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> SumAsync(Expression<Func<T, int?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<int> SumAsync(Expression<Func<T, int>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> SumAsync(Expression<Func<T, int?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> SumAsync(Expression<Func<T, float>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> SumAsync(Expression<Func<T, float?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> SumAsync(Expression<Func<T, float>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> SumAsync(Expression<Func<T, float?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> SumAsync(Expression<Func<T, double>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> SumAsync(Expression<Func<T, double?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> SumAsync(Expression<Func<T, double>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> SumAsync(Expression<Func<T, double?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> SumAsync(Expression<Func<T, decimal>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> SumAsync(Expression<Func<T, decimal?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> SumAsync(Expression<Func<T, decimal?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.SumAsync(selector).ConfigureAwait(false);
        }

        #endregion Sum

        #region Min

        public async Task<int> MinAsync(Expression<Func<T, int>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> MinAsync(Expression<Func<T, int?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<int> MinAsync(Expression<Func<T, int>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> MinAsync(Expression<Func<T, int?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> MinAsync(Expression<Func<T, float>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> MinAsync(Expression<Func<T, float?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> MinAsync(Expression<Func<T, float>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> MinAsync(Expression<Func<T, float?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> MinAsync(Expression<Func<T, double>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> MinAsync(Expression<Func<T, double?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> MinAsync(Expression<Func<T, double>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> MinAsync(Expression<Func<T, double?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> MinAsync(Expression<Func<T, decimal>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> MinAsync(Expression<Func<T, decimal?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> MinAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> MinAsync(Expression<Func<T, decimal?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MinAsync(selector).ConfigureAwait(false);
        }

        #endregion

        #region Max

        public async Task<int> MaxAsync(Expression<Func<T, int>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> MaxAsync(Expression<Func<T, int?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<int> MaxAsync(Expression<Func<T, int>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<int?> MaxAsync(Expression<Func<T, int?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> MaxAsync(Expression<Func<T, float>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> MaxAsync(Expression<Func<T, float?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<float> MaxAsync(Expression<Func<T, float>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<float?> MaxAsync(Expression<Func<T, float?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> MaxAsync(Expression<Func<T, double>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> MaxAsync(Expression<Func<T, double?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<double> MaxAsync(Expression<Func<T, double>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<double?> MaxAsync(Expression<Func<T, double?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> MaxAsync(Expression<Func<T, decimal>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> MaxAsync(Expression<Func<T, decimal?>> selector)
        {
            var dbQuery = mQueryGenerator.Invoke(null);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal> MaxAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        public async Task<decimal?> MaxAsync(Expression<Func<T, decimal?>> selector, Expression<Func<T, bool>> where)
        {
            var dbQuery = mQueryGenerator.Invoke(null).Where(@where);

            return await dbQuery.MaxAsync(selector).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Public methods
        public IList<T> GetAll(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var list = dbQuery.ToList();

            return list;
        }

        public T[] GetAllArray(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var list = dbQuery.ToArray();

            return list;
        }

        public T[] GetAllReadonly(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var list = dbQuery.ToArray();

            return list;
        }

        public async Task<IList<T>> GetAllAsync(IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var list = await dbQuery.ToListAsync().ConfigureAwait(false);

            return list;
        }

        public async Task<IList<T>> GetAllAsync(IList<Guid> ids, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var list = await dbQuery.ToListAsync().ConfigureAwait(false);

            return list;
        }

        public T[] GetArray(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties).Where(@where);

            var list = dbQuery.ToArray();

            return list;
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties).Where(@where);

            var list = dbQuery.ToList();

            return list;
        }

        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties).Where(@where);

            var list = await dbQuery.ToListAsync().ConfigureAwait(false);

            return list;
        }

        public T GetSingle(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var item = dbQuery.FirstOrDefault(@where);

            return item;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            var dbQuery = mQueryGenerator.Invoke(navigationProperties);

            var item = await dbQuery.FirstOrDefaultAsync(@where).ConfigureAwait(false);

            return item;
        }

        public IQueryable<T> GetAllQuery(IList<string> navigationProperties = null)
        {
            return mQueryGenerator.Invoke(navigationProperties);
        }

        public IQueryable<T> GetListQuery(Expression<Func<T, bool>> where, IList<string> navigationProperties = null)
        {
            return mQueryGenerator.Invoke(navigationProperties).Where(@where);
        }

        #endregion

        #region Protected methods

        protected T Add(T item)
        {
            mDbSet.Add(item);

            Context.SaveChanges();

            return item;
        }

        protected async Task<T> AddAsync(T item)
        {
            mDbSet.Add(item);

            await Context.SaveChangesAsync().ConfigureAwait(false);

            return item;
        }

        protected IList<T> Add(IList<T> items)
        {
            mDbSet.AddRange(items);

            Context.SaveChanges();

            return items;
        }

        protected async Task<IList<T>> AddAsync(IList<T> items)
        {
            mDbSet.AddRange(items);

            await Context.SaveChangesAsync().ConfigureAwait(false);

            return items;
        }

        protected T Change(T item)
        {
            Context.Entry(item).State = EntityState.Modified;

            Context.SaveChanges();

            return item;
        }

        protected async Task<T> ChangeAsync(T item)
        {
            Context.Entry(item).State = EntityState.Modified;

            await Context.SaveChangesAsync().ConfigureAwait(false);

            return item;
        }

        protected IList<T> Change(IList<T> items)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;

            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Modified;
            }

            Context.Configuration.AutoDetectChangesEnabled = true;

            Context.SaveChangesAsync();

            return items;
        }

        protected async Task<IList<T>> ChangeAsync(IList<T> items)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;

            foreach (var item in items)
            {
                Context.Entry(item).State = EntityState.Modified;
            }

            Context.Configuration.AutoDetectChangesEnabled = true;

            await Context.SaveChangesAsync().ConfigureAwait(false);

            return items;
        }

        protected void Remove(T item)
        {
            if (Context.Entry(item).State == EntityState.Detached)
            {
                mDbSet.Attach(item);
            }

            mDbSet.Remove(item);

            Context.SaveChanges();
        }

        protected async Task RemoveAsync(T item)
        {
            if (Context.Entry(item).State == EntityState.Detached)
            {
                mDbSet.Attach(item);
            }

            mDbSet.Remove(item);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        protected void Remove(IList<T> items)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;

            foreach (var item in items.Where(item => Context.Entry(item).State == EntityState.Detached))
            {
                mDbSet.Attach(item);
            }

            Context.Configuration.AutoDetectChangesEnabled = true;

            mDbSet.RemoveRange(items);

            Context.SaveChanges();
        }

        protected async System.Threading.Tasks.Task RemoveAsync(IList<T> items)
        {
            Context.Configuration.AutoDetectChangesEnabled = false;

            foreach (var item in items.Where(item => Context.Entry(item).State == EntityState.Detached))
            {
                mDbSet.Attach(item);
            }

            Context.Configuration.AutoDetectChangesEnabled = true;

            mDbSet.RemoveRange(items);

            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        #endregion

        #region Private methods

        private IQueryable<T> GenerateNonTrackingQuery(IList<string> navigationProperties)
        {
            return mDbSet.AsNoTracking().ApplyNavigationProperties(navigationProperties);
        }

        private IQueryable<T> GenerateQuery(IList<string> navigationProperties)
        {
            return mDbSet.ApplyNavigationProperties(navigationProperties);
        }

        #endregion
    }
}