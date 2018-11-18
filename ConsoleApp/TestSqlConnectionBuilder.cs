using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp
{
    public class TestSqlConnectionBuilder
    {
        public static void InitTest()
        {
            //"server=35.236.185.220;port=3306;user=root;password=nghia1996;database=kinta"
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder("server=35.236.185.220;port=3306;user=root;password=nghia1996;database=kinta");

            string server = builder.DataSource;
            string database = builder.InitialCatalog;


        }
    }
}
