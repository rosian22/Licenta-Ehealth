using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EHealth.DataLayer.Interfaces;


namespace EHealth.BusinessLogic.Workflow.Interfaces
{
    public interface IConfigurableQuery<TEntity> : IDisposable
        where TEntity : class, IDataAccessObject
    {
        bool IsValid { get; }

        IOrderedConfigurableQuery<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> expression);

        IOrderedConfigurableQuery<TEntity> OrderByDesc<TKey>(Expression<Func<TEntity, TKey>> expression);

        IConfigurableQuery<TEntity> Paginate(int pageNumber, int numberOfItemsPerPage);

        IList<TEntity> Execute();

        Task<IList<TEntity>> ExecuteAsync();

        int Count();

        IQueryable<TEntity> GetQuery();

    }
}
