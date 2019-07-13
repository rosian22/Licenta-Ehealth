using System;

namespace Deventure.Common.Interfaces
{
    public interface ISinglePkModel: IModel
    {
         Guid Id { get; set; }
    }
}