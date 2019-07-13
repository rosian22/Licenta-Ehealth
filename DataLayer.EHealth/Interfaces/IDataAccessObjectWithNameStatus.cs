using System;

namespace EHealth.DataLayer.Interfaces
{
    public interface IDataAccessObjectWithNameStatus : ISinglePkDataAccessObject
    {
        string Name { get; set; }
        int Status { get; set; }
    }
}