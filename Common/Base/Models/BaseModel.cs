using Common.Attribute;
using System;

namespace Common.Models
{
    public abstract class BaseModel : IEditTime
    {
        [DbFieldName(FieldName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbFieldName(FieldName = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
