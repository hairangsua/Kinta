﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.Models
{
    public class CategoryModel
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ParentCode { get; set; }

        public string ChildCode { get; set; }

        public string Path { get; set; }

        public string Tag { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
