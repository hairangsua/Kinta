using Kinta.Persistence.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleApp
{
    public class TestConnection
    {
        public static void InitTest()
        {

            var _connectionInfo = ConnectionStringInfo.GetConnectionByName("db_kinta");
            if (_connectionInfo == null)
            {
                throw new Exception("Can not get connection info");
            }

            var con = new MySqlConnection(_connectionInfo.Value);
            con.EnsureOpen();
            using (con)
            {
                using (var ts = con.BeginTransaction())
                {
               
                }
            }
            //con.state = close after run out of using


        }

        public class WrappedRepo<TRepo> : IDbTransaction
        {
            public IDbConnection Connection => throw new NotImplementedException();

            public IsolationLevel IsolationLevel => throw new NotImplementedException();

            public void Commit()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public void Rollback()
            {
                throw new NotImplementedException();
            }
        }
    }
}
