using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kinta.Framework.Data
{
    public class KintaPropertyInfo
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }
        public DbType DbType { get; set; }
        public int Length { get; set; }
        public bool IsKey { get; set; }
        public Type ObjectType { get; set; }
        public object Value { get; set; }

    }
}
