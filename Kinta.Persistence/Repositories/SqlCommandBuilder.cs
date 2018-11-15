using Kinta.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using SqlKata;
using SqlKata.Compilers;

namespace Kinta.Persistence.Repositories
{
    public static class SqlCommandBuilder
    {
        public static string SqlInsertBuilder<TEntity>(Dictionary<string, string> dicDbColumn, string tableName)
        {
            if (tableName.IsEmpty())
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            if (dicDbColumn.IsEmpty())
            {
                throw new ArgumentNullException(nameof(dicDbColumn));
            }
            var q = new Query("").AsInsert(new { });
            var comp = new SqlServerCompiler();
            var rs = comp.Compile(q);

            var sql = rs.Sql;


            return $"INSERT INTO dbo.{tableName} ({string.Join(",", dicDbColumn.Keys)})"
          + $"VALUES ({string.Join(", ", _QueryParameter)})";
        }
    }
}
