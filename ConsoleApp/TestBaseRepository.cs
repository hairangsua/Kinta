﻿using Kinta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using static ConsoleApp.TestWhereBuilder;

namespace ConsoleApp
{
    public class TestBaseRepository
    {
        public class TestDbConnection : DbConnection
        {
            public override string ConnectionString { get => ""; set => throw new NotImplementedException(); }

            public override string Database => throw new NotImplementedException();

            public override string DataSource => throw new NotImplementedException();

            public override string ServerVersion => throw new NotImplementedException();

            public override ConnectionState State => throw new NotImplementedException();

            public override void ChangeDatabase(string databaseName)
            {
                throw new NotImplementedException();
            }

            public override void Close()
            {
                throw new NotImplementedException();
            }

            public override void Open()
            {
                throw new NotImplementedException();
            }

            protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
            {
                throw new NotImplementedException();
            }

            protected override DbCommand CreateDbCommand()
            {
                throw new NotImplementedException();
            }
        }

        public static void InitTest()
        {
            var uow = new UnitOfWork(new TestDbConnection());
            var repo = new BaseRepository<AModel>(uow);
            var now = DateTime.Now;
            var lstA = repo.Find(x => x.Code == "someCode" && x.BirthDay == now && x.Hobbiy == "porn");
        }
    }
}
