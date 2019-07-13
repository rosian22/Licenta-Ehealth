using DataLayer.EHealth;
using EHealth.BusinessLogic.Workflow.Interfaces;
using EHealth.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UpWorky.BusinessLogic.Workflow;

namespace EHealth.BusinessLogic.Workflow
{
    public class ConfigurableQuery<TEntity> : IConfigurableQuery<TEntity>
        where TEntity : class, IDataAccessObject
    {
        private readonly Entities mContext;
        private IQueryable<TEntity> mDbQuery;

        public ConfigurableQuery()
        {
        }

        public ConfigurableQuery(Entities context, IQueryable<TEntity> dbQuery)
        {
            mContext = context;
            mDbQuery = dbQuery;
        }

        public bool IsValid => mContext != null && mDbQuery != null;

        public IOrderedConfigurableQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (!IsValid)
            {
                return new OrderedConfigurableQuery<TEntity>();
            }

            return new OrderedConfigurableQuery<TEntity>(mContext, mDbQuery.OrderBy(expression));
        }

        public IOrderedConfigurableQuery<TEntity> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> expression)
        {
            if (!IsValid)
            {
                return new OrderedConfigurableQuery<TEntity>();
            }

            return new OrderedConfigurableQuery<TEntity>(mContext, mDbQuery.OrderByDescending(expression));
        }

        public IConfigurableQuery<TEntity> Paginate(int pageNumber, int numberOfItemsPerPage)
        {
            if (IsValid)
            {
                mDbQuery = mDbQuery.Skip(pageNumber * numberOfItemsPerPage).Take(numberOfItemsPerPage);
            }

            return this;
        }

        public IList<TEntity> Execute()
        {
            return mDbQuery.ToList();
        }

        public async Task<IList<TEntity>> ExecuteAsync()
        {
            return await mDbQuery.ToListAsync().ConfigureAwait(false);
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
    }
}
