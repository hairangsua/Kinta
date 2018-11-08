using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Domain.Attributes
{
    public class DbColumnAttribute : System.Attribute
    {
        public string FieldName { get; set; }

        public DbColumnAttribute()
        {
        }
    }
}
