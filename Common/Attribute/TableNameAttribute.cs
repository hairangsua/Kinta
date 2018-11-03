using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attribute
{
    public class TableNameAttribute : System.Attribute
    {
        public string TableName { get; private set; }

        public TableNameAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
