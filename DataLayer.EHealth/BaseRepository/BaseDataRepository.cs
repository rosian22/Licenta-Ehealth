using System;
using System.Collections.Generic;
using EntityFrameworkExtras.EF6;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataLayer.EHealth;

namespace EHealth.DataLayer.Repositories
{
    public abstract class BaseDataRepository : IDisposable
    {
        private const string CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE = "Tried to use repository with null context";
        private Entities mContext;

        public abstract bool IsEntityTrackingOn { get; set; }

        public virtual Entities Context
        {
            get { return mContext; }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(CONTEXT_NULL_REFERENCE_EXCEPTION_MESSAGE);
                }

                value.Configuration.LazyLoadingEnabled = false;

                mContext = value;
            }
        }

        public IEnumerable<T> ExecuteStoredProcedureList<T>(object storedProcedure)
        {
            return mContext.Database.ExecuteStoredProcedure<T>(storedProcedure);
        }

        public void ExecuteStoredProcedure(object storedProcedure)
        {
             mContext.Database.ExecuteStoredProcedure(storedProcedure);
        }

        #region Raw SQL

        public int ExecuteSqlCommand(string sql, params object[] p)
        {
            return mContext.Database.ExecuteSqlCommand(sql, p);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] p)
        {
            return await mContext.Database.ExecuteSqlCommandAsync(sql, p).ConfigureAwait(false);
        }

        #endregion

        #region Disposing logic

        public void Dispose()
        {
            Context.Dispose();
        }

        #endregion
    }
}