using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public static class SqlConection
    {
        public static IDbConnection EnsureOpen(this IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (connection.State != ConnectionState.Open)
            {
                //TO DO: Cần WrappedConnection
                connection.Open();
            }

            return connection;
        }
    }
}
