using DataLayer.EHealth;
using EHealth.BusinessLogic.Workflow.Interfaces;
using EHealth.DataLayer.Repositories;
using System;
using System.Data.Entity;

namespace EHealth.BusinessLogic.Workflow
{
    public class RepoUnitOfWork : IUnitOfWork
    {
        private const string ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED = "The transaction was not finalized by the user";

        private Entities mContext;

        private DbContextTransaction mTransaction;
        private bool mIsTransactionFinalized;

        private readonly Type mScope;

        private RepoUnitOfWork()
        {
            InitializeUnitOfWork();
        }

        private RepoUnitOfWork(Type scope) : this()
        {
            mScope = scope;
        }

        public static T CreateRepository<T>() where T : BaseDataRepository, new()
        {
            var repository = new T();
            repository.IsEntityTrackingOn = false;
            return repository;
        }
        public static T CreateTrackingRepository<T>() where T : BaseDataRepository, new()
        {
            var repository = new T();
            repository.IsEntityTrackingOn = true;

            return repository;
        }

        #region Factory logic

        /// <summary>
        /// Instantiate an object of type RepoUnitOfWork without a scope for logging purposes.
        /// This UnitOfWork will track object changes.
        /// </summary>
        /// <returns>An instance of the RepoUnitOfWork class</returns>
        public static RepoUnitOfWork New() => new RepoUnitOfWork();

        /// <summary>
        /// Instantiate an object of type RepoUnitOfWork using a scope for logging purposes.
        /// This UnitOfWork will track object changes.
        /// </summary>
        /// <returns>An instance of the RepoUnitOfWork class</returns>
        public static RepoUnitOfWork New<T>() where T : class => new RepoUnitOfWork(typeof(T));

        #endregion

        #region Disposing Logic

        public void Dispose()
        {
            if (mTransaction != null)
            {
                mTransaction.Dispose();
                mTransaction = null;

                if (!mIsTransactionFinalized)
                {
                    if (mScope != null)
                    {
                        //LogHelper.LogInfo(mScope, ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED);
                    }
                    else
                    {
                        //LogHelper.LogInfo<RepoUnitOfWork>(ERROR_MESSAGE_TRANSACTION_NOT_FINALIZED);
                    }
                }
            }

            if (mContext != null)
            {
                mContext.Dispose();
                mContext = null;
            }
        }

        #endregion

        #region Tracking Repo Factory logic

        public T TrackingRepository<T>() where T : BaseDataRepository, new()
        {

            var repository = new T();

            repository.Context = mContext;
            repository.IsEntityTrackingOn = true;

            return repository;
        }

        #endregion

        #region Non-Tracking Repo Factory logic

        public T Repository<T>() where T : BaseDataRepository, new()
        {
            return new T();
        }

        #endregion

        #region Transactions logic

        public void FinalizeTransaction(bool isTransactionSuccessful)
        {
            if (isTransactionSuccessful)
            {
                CommitTransaction();
            }
            else
            {
                RollbackTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (mTransaction == null)
            {
                throw new NullReferenceException("An SQL transaction was not initialized to run the Commit action");
            }

            if (mIsTransactionFinalized)
            {
                throw new InvalidOperationException("Cannot commit a transaction that was already commited or aborted");
            }

            mIsTransactionFinalized = true;
            mTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (mTransaction == null)
            {
                throw new NullReferenceException("An SQL transaction was not initialized to run the Rollback action");
            }

            if (mIsTransactionFinalized)
            {
                throw new InvalidOperationException("Cannot rollback a transaction that was already commited or aborted");
            }

            mIsTransactionFinalized = true;
            mTransaction.Rollback();
        }

        #endregion

        #region Initialization

        private void InitializeUnitOfWork()
        {
            mContext = new Entities();
            mTransaction = mContext.Database.BeginTransaction();
        }

        #endregion
    }
}