﻿using Common.Attribute;
using System;

namespace Common.Models
{
    public abstract class BaseModel : IEditTime
    {
        [DbColumn(FieldName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbColumn(FieldName = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
