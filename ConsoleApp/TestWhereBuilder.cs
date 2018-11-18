using Common.SQLFromExpression;
using Kinta.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class TestWhereBuilder
    {
        [DbName("213")]
        public class AModel
        {
            [DbColumn(Name = "code")]
            public string Code { get; set; }

            [DbColumn(Name = "birth_day")]
            public DateTime BirthDay { get; set; }

            [DbColumn(Name = "hobby")]
            public string Hobbiy { get; set; }


        }
        public static void InitTest()
        {
            //var a = new WherePart();
            var lst = new List<string> { "12", "33" };
            var builder = new WhereBuilder<AModel>();

            var date = DateTime.Now;

            var a = builder.ToSql(x => x.Code == "112" && x.BirthDay == date && lst.Contains(x.Hobbiy));

            SqlCommand cmd = new SqlCommand(a.RawSql, new SqlConnection(""));

            foreach (var key in a.Parameters.Keys)
            {
                cmd.Parameters.AddWithValue($"{key}", a.Parameters[key]);
            }

            var b = a.RawSql;
        }

    }
}
