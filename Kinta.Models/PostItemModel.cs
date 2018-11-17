using Kinta.Domain.Attributes;
using Kinta.Domain.Entities;
using System;

namespace Kinta.Models.Entities
{
    [DbName("post_item"), RegisterInfo]
    public class PostItemModel : BaseModel
    {
        [DbColumn(Name = "id")]
        public string Id { get; set; }

        [DbColumn(Name = "title")]
        public string Title { get; set; }

        [DbColumn(Name = "ref_link")]
        public string RefLink { get; set; }

        [DbColumn(Name = "images")]
        public string Images { get; set; }

        [DbColumn(Name = "category")]
        public string Category { get; set; }

        [DbColumn(Name = "url")]
        public string Url { get; set; }

        [DbColumn(Name = "tag")]
        public string Tag { get; set; }

        [DbColumn(Name = "created_time")]
        public DateTime CreatedTime { get; set; }

        [DbColumn(Name = "updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}