using DataLayer.EHealth;
using EHealth.BusinessLogic.Workflow;
using EHealth.BusinessLogic.Workflow.Interfaces;
using EHealth.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UpWorky.BusinessLogic.Workflow
{
    public class OrderedConfigurableQuery<TEntity> : IOrderedConfigurableQuery<TEntity>
        where TEntity : class, IDataAccessObject
    {
        private readonly Entities mContext;
        private IOrderedQueryable<TEntity> mDbQuery;

        public OrderedConfigurableQuery()
        {
        }

        public OrderedConfigurableQuery(Entities context, IOrderedQueryable<TEntity> dbQuery)
        {
            mContext = context;
            mDbQuery = dbQuery;
        }

        public bool IsValid => mContext != null && mDbQuery != null;

        public IOrderedConfigurableQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.OrderBy(expression);
            }

            return this;
        }

        public IOrderedConfigurableQuery<TEntity> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.OrderByDescending(expression);
            }

            return this;
        }

        public IOrderedConfigurableQuery<TEntity> ThenBy<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.ThenBy(expression);
            }

            return this;
        }

        public IOrderedConfigurableQuery<TEntity> ThenByDesc<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.ThenByDescending(expression);
            }

            return this;
        }

        public IConfigurableQuery<TEntity> Paginate(int pageNumber, int numberOfItemsPerPage)
        {
            if (!IsValid)
            {
                return this;
            }

            return new ConfigurableQuery<TEntity>(mContext, mDbQuery.Skip(pageNumber * numberOfItemsPerPage).Take(numberOfItemsPerPage));
        }

        public void Dispose()
        {
            mContext?.Dispose();
        }

        public int Count()
        {
            return this.mDbQuery.Count();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return this.mDbQuery;
        }

        public IList<TEntity> Execute()
        {
            return mDbQuery.ToList();
        }

        public async Task<IList<TEntity>> ExecuteAsync()
        {
            var result = await mDbQuery.ToListAsync().ConfigureAwait(false);
            return result;
        }

    }
}
