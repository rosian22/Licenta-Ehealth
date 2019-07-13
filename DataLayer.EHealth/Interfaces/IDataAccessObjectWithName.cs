using System;

namespace EHealth.DataLayer.Interfaces
{
    public interface IDataAccessObjectWithName : ISinglePkDataAccessObject
    {
        string Name { get; set; }
    }
}