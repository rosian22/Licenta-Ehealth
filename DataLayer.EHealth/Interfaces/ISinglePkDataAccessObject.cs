using System;

namespace EHealth.DataLayer.Interfaces
{
    public interface ISinglePkDataAccessObject : IDataAccessObject
    {
        Guid Id { get; set; }
    }
}