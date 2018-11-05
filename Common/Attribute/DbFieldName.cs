using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attribute
{
    public class DbColumnAttribute : System.Attribute
    {
        public string FieldName { get; set; }

        public DbColumnAttribute()
        {
        }
    }
}
