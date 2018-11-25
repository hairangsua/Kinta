using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kinta.Framework.Data
{
    public static class SqlConectionExtension
    {
        public static IDbConnection EnsureOpen(this IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (connection.State != ConnectionState.Open)
            {
                //TODO: Cần WrappedConnection
                connection.Open();
            }

            return connection;
        }
    }
}
