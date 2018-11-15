using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        Compiler Compiler { get; }
        event Action OnComit;
        event Action OnRollBack;
    }
}
