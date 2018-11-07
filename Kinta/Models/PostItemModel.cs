using Common.Attribute;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinta.Models
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
    }
}