using System;
using System.Linq.Expressions;
using EHealth.DataLayer.Interfaces; 

namespace EHealth.BusinessLogic.Workflow.Interfaces
{
    public interface IOrderedConfigurableQuery<TEntity> : IConfigurableQuery<TEntity>
        where TEntity : class, IDataAccessObject
    {
        IOrderedConfigurableQuery<TEntity> ThenBy<TKey>(Expression<Func<TEntity, TKey>> expression);

        IOrderedConfigurableQuery<TEntity> ThenByDesc<TKey>(Expression<Func<TEntity, TKey>> expression);    
    }
}
