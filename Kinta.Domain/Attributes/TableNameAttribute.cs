using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Domain.Attributes
{
    public class DbNameAttribute : System.Attribute
    {
        public string Name { get; private set; }

        public DbNameAttribute(string tableName)
        {
            Name = tableName;
        }
    }
}
