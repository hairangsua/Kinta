using Kinta.Models;
using SqlKata;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Text;
using Common.SQLKataExtension;
using System.Data.SqlClient;
using SqlKata.Execution;

namespace ConsoleApp
{
    class TestSqlKata
    {
        public static void Test()
        {
            var compiler = new SqlServerCompiler();

            var query = new Query("").Where("", 1).Where("Status", "Active");
            SqlResult result = compiler.Compile(query);

            string sql = result.Sql;
        }

        public static void CreateQuery()
        {
            var q = Query<CategoryModel, MySqlCompiler>.Create();

            var connection = new SqlConnection("...");
            var compiler = new MySqlCompiler();
            var db = new QueryFactory(connection, compiler);
            
        }
    }
}
