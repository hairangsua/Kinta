﻿using System;
using System.Data;

namespace Kinta.Framework.Data.MappingAttributes
{
    public class DbColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public DbType DbType { get; set; }
        public bool IsKey { get; set; }
        public int Length { get; set; }

        public DbColumnAttribute()
        {
        }
    }
}
