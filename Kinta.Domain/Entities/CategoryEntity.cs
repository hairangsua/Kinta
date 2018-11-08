using Kinta.Domain.Attributes;

namespace Kinta.Domain.Entities
{
    [DbName("category"), RegisterInfo]
    public class CategoryEntity : BaseEntity
    {
        [DbColumn(FieldName = "id")]
        public string Id { get; set; }

        [DbColumn(FieldName = "code")]
        public string Code { get; set; }

        [DbColumn(FieldName = "name")]
        public string Name { get; set; }

        [DbColumn(FieldName = "description")]
        public string Description { get; set; }

        [DbColumn(FieldName = "parent_code")]
        public string ParentCode { get; set; }

        [DbColumn(FieldName = "child_code")]
        public string ChildCode { get; set; }

        [DbColumn(FieldName = "path")]
        public string Path { get; set; }

        [DbColumn(FieldName = "tag")]
        public string Tag { get; set; }

    }
}
