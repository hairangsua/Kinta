using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Application.Models
{
    public class PostItemModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string RefLink { get; set; }

        public string Images { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }

        public string Tag { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }                       
        
    }
}
