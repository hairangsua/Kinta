using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public class BaseDbConnection : DbConnection, IDbConnection
    {
        //"server=35.236.185.220;port=3306;user=root;password=nghia1996;database=kinta"
        public BaseDbConnection()
        {

        }

        private string _connectionString;
        private string _database;
        private string _serverVersion;
        private string _dataSource;
        private ConnectionState _state;

        public BaseDbConnection(string connectionString)
        {
            _connectionString = connectionString;

            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = _connectionString;

            _dataSource = builder["Data Source"] as string;
            _database = builder["Initial Catalog"] as string;
        }

        public override string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        public override string Database => _database;

        public override string DataSource => _dataSource;

        public override string ServerVersion => _serverVersion;

        public override ConnectionState State => _state;

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            //TO DO: log here

        }

        public override void Open()
        {
            //TO DO: log here
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            //TO DO: log here
            throw new NotImplementedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            //TO DO: log here
            throw new NotImplementedException();
        }
    }
}
