using System;
using EHealth.DataLayer.Repositories;

namespace EHealth.BusinessLogic.Workflow.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        T TrackingRepository<T>() where T : BaseDataRepository,new();

        void CommitTransaction();

        void RollbackTransaction();

        void FinalizeTransaction(bool isTransactionSuccessful);
    }
}
