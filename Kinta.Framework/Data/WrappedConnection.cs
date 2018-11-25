using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kinta.Framework.Data
{
    public class WrappedConnection : IDbConnection
    {
        private IDbConnection _actualConnection;
        public WrappedConnection(IDbConnection actualConnection)
        {
            _actualConnection = actualConnection;
        }

        public string ConnectionString
        {
            get => _actualConnection.ConnectionString;
            set => _actualConnection.ConnectionString = value;
        }

        public int ConnectionTimeout
        {
            get { return _actualConnection.ConnectionTimeout; }
        }

        public string Database
        {
            get { return _actualConnection.Database; }
        }

        public ConnectionState State
        {
            get
            {
                return _actualConnection.State;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}
