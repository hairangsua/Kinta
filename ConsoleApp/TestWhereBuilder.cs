using Common.SQLFromExpression;
using Kinta.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class TestWhereBuilder
    {
        public static void use()
        {
            //var a = new WherePart();
            var builder = new WhereBuilder<CategoryModel>();
            var a = builder.ToSql(x => x.Code == "asjd");
        }

    }
}
