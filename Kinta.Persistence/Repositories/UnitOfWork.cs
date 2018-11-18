using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SqlKata.Compilers;

namespace Kinta.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private Action _commit;
        private Action _rollback;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            connection.EnsureOpen();
            _transaction = connection.BeginTransaction();
        }

        public IDbConnection Connection { get { return _connection; } }

        public event Action OnComit
        {
            add { _commit += value; }
            remove { _commit -= value; }
        }

        public event Action OnRollBack
        {
            add { _rollback += value; }
            remove { _rollback -= value; }
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new ArgumentNullException(nameof(_transaction));
            }

            _transaction.Commit();
            _transaction = null;

            if (_commit != null)
            {
                _commit();
                _commit = null;
            }
        }

        public void Dispose()
        {
            if (_transaction == null)
            {
                _transaction.Dispose();
                _transaction = null;

                if (_rollback != null)
                {
                    _rollback();
                    _rollback = null;
                }
            }
        }
    }
}
