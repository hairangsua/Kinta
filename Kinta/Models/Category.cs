using Common.Attribute;
using Common.Models;
using System;

namespace Kinta.Models
{
    [TableName("category")]
    public class CategoryModel : BaseModel
    {
        [DbFieldName(FieldName = "id")]
        public string Id { get; set; }

        [DbFieldName(FieldName = "code")]
        public string Code { get; set; }

        [DbFieldName(FieldName = "name")]
        public string Name { get; set; }

        [DbFieldName(FieldName = "description")]
        public string Description { get; set; }

        [DbFieldName(FieldName = "parent_code")]
        public string ParentCode { get; set; }

        [DbFieldName(FieldName = "child_code")]
        public string ChildCode { get; set; }

        [DbFieldName(FieldName = "path")]
        public string Path { get; set; }

        [DbFieldName(FieldName = "tag")]
        public string Tag { get; set; }
    }
}
