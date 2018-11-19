using Kinta.Domain.Attributes;
using System;

namespace Kinta.Models.Entities
{
    [DbName("category"), RegisterInfo]
    public class CategoryModel : BaseModel
    {
        [DbColumn(Name = "id")]
        public string Id { get; set; }

        [DbColumn(Name = "code")]
        public string Code { get; set; }

        [DbColumn(Name = "name")]
        public string Name { get; set; }

        [DbColumn(Name = "description")]
        public string Description { get; set; }

        [DbColumn(Name = "parent_code")]
        public string ParentCode { get; set; }

        [DbColumn(Name = "child_code")]
        public string ChildCode { get; set; }

        [DbColumn(Name = "path")]
        public string Path { get; set; }

        [DbColumn(Name = "tag")]
        public string Tag { get; set; }

        [DbColumn(Name = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbColumn(Name = "updated_time")]
        public DateTime UpdatedTime { get; set; }

    }
}
