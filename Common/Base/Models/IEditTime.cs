using Common.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public interface IEditTime
    {

        DateTime CreatedTime { get; set; }


        DateTime UpdatedTime { get; set; }
    }
}
