using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attribute
{
    public class DbFieldNameAttribute : System.Attribute
    {
        public string FieldName { get; set; }

        public DbFieldNameAttribute()
        {
        }
    }
}
