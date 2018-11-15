using Kinta.Domain.Attributes;
using Kinta.Domain.Entities;
using System;

namespace Kinta.Models.Entities
{
    [DbName("post_item"), RegisterInfo]
    public class PostItemModel : BaseModel
    {
        [DbColumn(FieldName = "id")]
        public string Id { get; set; }

        [DbColumn(FieldName = "title")]
        public string Title { get; set; }

        [DbColumn(FieldName = "ref_link")]
        public string RefLink { get; set; }

        [DbColumn(FieldName = "images")]
        public string Images { get; set; }

        [DbColumn(FieldName = "category")]
        public string Category { get; set; }

        [DbColumn(FieldName = "url")]
        public string Url { get; set; }

        [DbColumn(FieldName = "tag")]
        public string Tag { get; set; }

        [DbColumn(FieldName = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbColumn(FieldName = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}