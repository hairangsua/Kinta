using System;
using System.Data;

namespace Kinta.Framework.Data
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        event Action OnComit;
        event Action OnRollBack;
    }
}
