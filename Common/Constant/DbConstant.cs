using Kinta.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constant
{
    public static class DbConstant
    {
        public const string KintaDb = "Kinta";

        public static string SetConnectionString(string dbName)
        {
            if (dbName.IsEmpty())
            {
                throw new ArgumentNullException(nameof(dbName));
            }

            return $@"Data Source=DESKTOP-763MQFN\SQLEXPRESS;Initial Catalog={dbName};Integrated Security=True";
        }
    }
}
