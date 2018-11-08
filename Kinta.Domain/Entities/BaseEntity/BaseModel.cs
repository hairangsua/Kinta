using Kinta.Domain.Attributes;
using System;

namespace Kinta.Domain.Entities
{
    public abstract class BaseEntity : IEditTime
    {
        [DbColumn(FieldName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbColumn(FieldName = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
